using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ceng396.Models.DB;

namespace Ceng396.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Ceng396.Models.DB.WWTTMSContext _context;

        public CreateModel(Ceng396.Models.DB.WWTTMSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Subscriber Subscriber { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Subscriber.Add(Subscriber);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
