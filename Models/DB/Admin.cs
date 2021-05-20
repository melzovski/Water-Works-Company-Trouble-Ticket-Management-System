using System;
using System.Collections.Generic;

namespace Ceng396.Models.DB
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }
        public int Password { get; set; }
    }
}
