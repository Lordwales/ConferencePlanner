using ConferenceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public static class EntityExtensions
    {
        public static ConferenceDTO.SpeakerResponse MapSpeakerResponse(this Speaker speaker) =>
            new ConferenceDTO.SpeakerResponse
            {
                Id = speaker.Id,
                Name = speaker.Name,
                Bio = speaker.Bio,
                WebSite = speaker.WebSite,
                Sessions = speaker.SessionSpeakers?
                    .Select(ss =>
                        new ConferenceDTO.Session
                        {
                            Id = ss.SessionId,
                            Title = ss.Session.Title
                        })
                    .ToList()
            };

        public static AttendeeResponse MapAttendeeResponse(this Attendee attendee) =>
            new AttendeeResponse
            {
                Id = attendee.Id,
                FirstName = attendee.FirstName,
                LastName = attendee.LastName,
                UserName = attendee.UserName,
                EmailAddress = attendee.EmailAddress,
                Sessions = attendee.SessionAttendees?
                    .Select(sa =>
                    new ConferenceDTO.Session
                    {
                        Id=sa.SessionId,
                        Title = sa.Session.Title
                    })
                .ToList()
            };

        public static SessionResponse MapSessionResponse(this Session session) =>
            new SessionResponse
            {
                Id = session.Id,
                Title = session.Title,
                Abstract = session.Abstract,
                StartTime = session.StartTime,
                EndTime = session.EndTime,
                TrackId = session.TrackId,
                Speakers = session.SessionSpeakers?
                    .Select(ss =>
                        new ConferenceDTO.Speaker
                        {
                            Id = ss.SpeakerId,
                            Name = ss.Speaker.Name
                        })
                    .ToList(),

                Attendees = session.SessionAttendees?
                    .Select(sa=>
                    new ConferenceDTO.Attendee
                    {
                        Id = sa.AttendeeId,
                        FirstName = sa.Attendee.FirstName,
                        LastName = sa.Attendee.LastName

                    })
                    .ToList(),

                Track = new ConferenceDTO.Track
                {
                    Id = session?.TrackId ?? 0,
                    Name = session.Track?.Name
                },

            };


        public static ConferenceResponse MapConferenceResponse(this Conference conference) =>
            new ConferenceResponse
            {
                Id = conference.Id,
                Name = conference.Name,
                
                Attendees = conference.ConferenceAttendees?
                    .Select(ca =>
                    new ConferenceDTO.Attendee
                    {
                        Id = ca.AttendeeId,
                        FirstName = ca.Attendee.FirstName,
                        LastName = ca.Attendee.LastName
                        

                    })
                    .ToList(),

                

            };
    }
}
