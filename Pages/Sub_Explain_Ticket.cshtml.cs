using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ceng396.Models.DB;

namespace Ceng396.Pages
{
    public class Sub_Explain_TicketModel : PageModel
    {
        private readonly Ceng396.Models.DB.WWTTMSContext _context;
        public Sub_Explain_TicketModel(Ceng396.Models.DB.WWTTMSContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public int Price { get; set; }


        public void OnGet()
        {
            Username = HttpContext.Session.GetString("username");

        }
        [BindProperty]
        public Subscriber Subscriber { get; set; }

        public Ticket Ticket { get; set; }
        private bool SubscriberExists(String Username)
        {
            return _context.Subscriber.Any(e => e.SubName == Username);
        }

        public void Save(Subscriber cust)
        {
            _context.Subscriber.Update(cust);
            _context.SaveChanges();
        }

        public IActionResult OnPostRegister()
        {
            string tckt = Request.Form["explain"];


            int? num = HttpContext.Session.GetInt32("number");
            var ticket = _context.Ticket.Single(a => a.SubId == num);
            ticket.TicketMessage = tckt;
            _context.SaveChanges();
            return RedirectToPage();




        }

    }
}