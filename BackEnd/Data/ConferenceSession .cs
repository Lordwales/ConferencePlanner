using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public class ConferenceSession
    {
        public int ConferenceId { get; set; }

        public Conference Conference { get; set; }

        public int SessionId { get; set; }

        public Session Session { get; set; }
    }
}
