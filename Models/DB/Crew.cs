using System;
using System.Collections.Generic;

namespace Ceng396.Models.DB
{
    public partial class Crew
    {
        public Crew()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int CrewId { get; set; }
        public int CrewPassword { get; set; }
        public int CrewAvailability { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
