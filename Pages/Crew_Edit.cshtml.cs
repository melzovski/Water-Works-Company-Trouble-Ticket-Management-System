using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ceng396.Models.DB;

namespace Ceng396.Pages
{
    public class CrewEditModel : PageModel
    {
        private readonly Ceng396.Models.DB.WWTTMSContext _context;

        public CrewEditModel(Ceng396.Models.DB.WWTTMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Crew Crew { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Crew = await _context.Crew.FirstOrDefaultAsync(m => m.CrewId == id);

            if (Crew == null)
            {
                return NotFound();
            }
            return Page();
        }

     
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Crew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrewExists(Crew.CrewId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return RedirectToPage("./Index");

        }

        private bool CrewExists(int id)
        {
            return _context.Crew.Any(e => e.CrewId == id);
        }
    }
}
