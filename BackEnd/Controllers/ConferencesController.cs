using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ConferencesController(ApplicationDbContext _context)
        {
            context = _context;
        }

        // GET: api/Conferences
        [HttpGet]
        public async Task<ActionResult<List<ConferenceDTO.ConferenceResponse>>> GetConference()
        {
            var conferences = await context.Conferences.AsNoTracking()
                                            .Include(c => c.ConferenceAttendees)
                                                .ThenInclude(c=> c.Attendee)
                                            .Select(c=>c.MapConferenceResponse())
                                            .ToListAsync(); 


                return conferences;
        }

        // GET: api/Conferences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConferenceDTO.ConferenceResponse>> GetConference(int id)
        {
            var conference = await context.Conferences.AsNoTracking()
                                            .Include(c => c.ConferenceAttendees)
                                                .ThenInclude(c => c.Attendee)
                                            .SingleOrDefaultAsync(c => c.Id == id);


            if (conference == null)
            {
                return NotFound();
            }

            return conference.MapConferenceResponse();
        }

        // PUT: api/Conferences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConference(int id, ConferenceDTO.Conference input)
        {
           


            var conference = await context.Conferences.FindAsync(id);

            if (conference == null)
            {
                return NotFound();
            }

            conference.Id = input.Id;
            conference.Name = input.Name;
            

            await context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Conferences
        [HttpPost]
        public async Task<ActionResult<Conference>> PostConference(ConferenceDTO.Conference input)
        {
           // context.Conferences.Add(conference);
           // await context.SaveChangesAsync();

           // return CreatedAtAction("GetConference", new { id = conference.Id }, conference);

            var conference = new Data.Conference
            {
                Name = input.Name,
                
            };

            context.Conferences.Add(conference);
            await context.SaveChangesAsync();

            var result = conference.MapConferenceResponse();

            return CreatedAtAction("GetConference", new { id = result.Id }, result);
        }

        private object Get()
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Conferences/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Conference>> DeleteConference(int id)
        {
            var conference = await context.Conferences.FindAsync(id);
            if (conference == null)
            {
                return NotFound();
            }

            context.Conferences.Remove(conference);
            await context.SaveChangesAsync();

            return conference;
        }

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload([FromForm]ConferenceFormat format, IFormFile file)
        {
            var loader = GetLoader(format);

            using (var stream = file.OpenReadStream())
            {
                await loader.LoadDataAsync(stream, context);
            }

            await context.SaveChangesAsync();

            return Ok();
        }

        private bool ConferenceExists(int id)
        {
            return context.Conferences.Any(e => e.Id == id);
        }

        private static DataLoader GetLoader(ConferenceFormat format)
        {
            if (format == ConferenceFormat.Sessionize)
            {
                return new SessionizeLoader();
            }
            return new DevIntersectionLoader();
        }

        public enum ConferenceFormat
        {
            Sessionize,
            DevIntersections
        }
    }
}
