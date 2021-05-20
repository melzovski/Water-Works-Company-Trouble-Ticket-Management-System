using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceng396.Models.DB;
using System.ComponentModel.DataAnnotations;

namespace Ceng396.Pages
{
    public class LoginModel : PageModel
    {
        
        [BindProperty]
        [Required]
        public string Username { get; set; }
        
        [BindProperty]
        [Required]
        public int Password { get; set; }
        public string Msg { get; set; }



        private readonly Ceng396.Models.DB.WWTTMSContext _context;

        public LoginModel(Ceng396.Models.DB.WWTTMSContext context)
        {
            _context = context;
        }

        public IList<Subscriber> Subscriber { get; set; }

        public async Task OnGetAsync()
        {
            Subscriber = await _context.Subscriber.ToListAsync();
        }
        private bool SubscriberExist(string username, int password)
        {
            bool usern = false, pass = false;
            usern = _context.Subscriber.Any(e => e.SubName == username);
            pass = _context.Subscriber.Any(e => e.SubPassword == password);
            if (usern == true && pass == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool AdminExists(int id, int password)
        {
            bool admin = false, apass = false;
            admin = _context.Admin.Any(e => e.Id == id);
            apass = _context.Admin.Any(e => e.Password == password);
            if (admin == true && apass == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CrewExists(int id, int password)
        {
            bool admin = false, apass = false;
            admin = _context.Crew.Any(e => e.CrewId == id);
            apass = _context.Crew.Any(e => e.CrewPassword == password);
            if (admin == true && apass == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult OnPost()
        {
            if (SubscriberExist(Username, Password))
            {
                //HttpContext.Session.SetString("username", Username);
                var cust = _context.Subscriber.Single(a => a.SubName == Username);
                HttpContext.Session.SetString("username", cust.SubName);
                HttpContext.Session.SetInt32("number", cust.SubId);
                // return RedirectToPage("Welcome");
                return RedirectToPage("Sub_Welcome");
            }
            else if (AdminExists(Convert.ToInt32(Username), Password))
            {
                // var cust = _context.Customers.Single(a => a.Username == Username);
                HttpContext.Session.SetString("username", Username);
                // securityManager.SignIn(HttpContext, cust);
                return RedirectToPage("Admin_Welcome");
            }
            else if (CrewExists(Convert.ToInt32(Username), Password))
            {
               //  var cust = _context.Crew.Single(a => a.CrewId == Username);
                HttpContext.Session.SetString("username", Username);
                
                // securityManager.SignIn(HttpContext, cust);
                return RedirectToPage("Crew_Welcome");
            }
            else
            {
                Msg = "Invalid UserName";
                return Page();
            }
        }

    }
}
