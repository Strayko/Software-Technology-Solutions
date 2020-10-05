using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

namespace ST.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Current = "Contact";
            
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SendEmail(FormModel model)
        {
            MailAddress to = new MailAddress("support@stsolution.com");
            MailAddress from = new MailAddress(model.Email);
            
            MailMessage message = new MailMessage(from, to);
            message.Subject = model.Subject;
            message.Body = model.Message;

            SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("1db59f41f06cf5", "0b4b4179e475e4"),
                EnableSsl = true
            };

            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}