using System;
using System.Collections.Generic;

namespace Ceng396.Models.DB
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public string TicketMessage { get; set; }
        public int TicketDone { get; set; }
        public int SubId { get; set; }
        public int CrewId { get; set; }
        

        public virtual Crew Crew { get; set; }
        public virtual Subscriber Sub { get; set; }
    }
}
