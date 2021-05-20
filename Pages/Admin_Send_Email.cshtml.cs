using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Ceng396.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ceng396.Pages
{
    public class Admin_Send_EmailModel : PageModel
    {
        private readonly Ceng396.Models.DB.WWTTMSContext _context;


        public Admin_Send_EmailModel(Ceng396.Models.DB.WWTTMSContext context)
        {
            _context = context;
        }

        public async Task SendEmailAsync(int num1)
        {
           
            //string username2 = HttpContext.Session.GetInt32("number");
            var Sub = _context.Subscriber.Single(a => a.SubId == num1);
            string To = Sub.SubEmail;
            string Subject = "Reservation for " + Sub.SubName;
            string Body = "Customer Name: " + Sub.SubName + " Customer Surname: " + Sub.SubSurname + " Your problem has been fixed.";
            MailMessage mm = new MailMessage();
            mm.To.Add(To); mm.Subject = Subject;
            mm.Body = Body; mm.IsBodyHtml = false;
            mm.From = new MailAddress("ceng382deneme@gmail.com");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential("ceng382deneme@gmail.com", "deneme12345")
            };
            await smtp.SendMailAsync(mm);
            //ViewData["Message"] = "The Mail Has Been Seen to " + sendmail.To;
        }

        public IList<Subscriber> subscribers { get; set; }

        public async Task OnGetAsync()
        {
            subscribers = await _context.Subscriber.ToListAsync();
        }

        public void Save(Subscriber cust)
        {
            _context.Subscriber.Update(cust);
            _context.SaveChanges();
        }

        public IActionResult OnPostRegister()
        {

            string num = Request.Form["number"];
            int num1 = Convert.ToInt32(num);
           _ = SendEmailAsync(num1);
            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}