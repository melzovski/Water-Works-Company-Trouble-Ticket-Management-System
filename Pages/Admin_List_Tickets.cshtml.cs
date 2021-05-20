using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceng396.Models.DB;

namespace Ceng396.Pages
{
    public class AdminListTicketsModel : PageModel
    {
        private readonly Ceng396.Models.DB.WWTTMSContext _context;

        public AdminListTicketsModel(Ceng396.Models.DB.WWTTMSContext context)
        {
            _context = context;
        }

        public IList<Ticket> tickets { get; set; }

        public IList<Crew> crew { get; set; }
        public async Task OnGetAsync()
        {
            tickets = await _context.Ticket.ToListAsync();
            crew = await _context.Crew.ToListAsync();
        }





    }
}