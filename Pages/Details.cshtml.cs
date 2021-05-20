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
    public class DetailsModel : PageModel
    {
        private readonly Ceng396.Models.DB.WWTTMSContext _context;

        public DetailsModel(Ceng396.Models.DB.WWTTMSContext context)
        {
            _context = context;
        }

        public Subscriber Subscriber { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subscriber = await _context.Subscriber.FirstOrDefaultAsync(m => m.SubId == id);

            if (Subscriber == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
