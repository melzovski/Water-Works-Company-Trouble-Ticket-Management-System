using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ceng396.Models.DB
{
    public partial class Subscriber
    {
        public Subscriber()
        {
            Ticket = new HashSet<Ticket>();
        }

        
        public int SubId { get; set; }
        [Required]
        public string SubName { get; set; }
        public string SubSurname { get; set; }
        [Required]
        public int SubPassword { get; set; }
        public string SubAddress { get; set; }
        public string SubEmail { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
