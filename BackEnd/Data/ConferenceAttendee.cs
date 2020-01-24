using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public class ConferenceAttendee
    {
        public int ConferenceId { get; set; }

        public Conference Conference { get; set; }

        public int AttendeeId { get; set; }

        public Attendee Attendee { get; set; }
    }

}
