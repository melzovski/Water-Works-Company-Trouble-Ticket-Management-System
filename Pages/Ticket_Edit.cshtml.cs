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
    public class TicketEditModel : PageModel
    {
        private readonly Ceng396.Models.DB.WWTTMSContext _context;

        public TicketEditModel(Ceng396.Models.DB.WWTTMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Ticket
                .Include(t => t.Crew)
                .Include(t => t.Sub).FirstOrDefaultAsync(m => m.TicketId == id);

            if (Ticket == null)
            {
                return NotFound();
            }
            ViewData["CrewId"] = new SelectList(_context.Crew, "CrewId", "CrewId");
            ViewData["SubId"] = new SelectList(_context.Subscriber, "SubId", "SubAddress");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(Ticket.TicketId))
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

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.TicketId == id);
        }
    }
}
