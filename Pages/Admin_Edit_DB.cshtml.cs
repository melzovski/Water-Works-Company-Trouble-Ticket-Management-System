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
    public class Admin_Edit_DBModel : PageModel
    {
        private readonly Ceng396.Models.DB.WWTTMSContext _context;

        public Admin_Edit_DBModel(Ceng396.Models.DB.WWTTMSContext context)
        {
            _context = context;
        }

        public IList<Subscriber> subscribers { get; set; }

        public async Task OnGetAsync()
        {
            subscribers = await _context.Subscriber.ToListAsync();
        }
    }
}