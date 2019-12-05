using Intex.Models;
using System.Net;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Intex.Controllers
{
    
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ViewBag.Support = "Please call Support at <b><u>801-555-1212</u></b>. Thank you!";
            return View();
        }

        public ActionResult Email(string email, string name)
        {
            ViewBag.Thanks = "Thank you " + name + ", your email has been sent! Our suppor specialists will send a response to " + email + ".";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(EmailFormModel model)
        {

            if (ModelState.IsValid)
            {
                var senderEmail = new MailAddress("rankIS403@gmail.com", "werenumber1");
                var receiverEmail = new MailAddress("rankIS403@gmail.com", "Receiver");
                var password = "werenumber1";
                var body = model.Message.ToString();
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = "From RANK",
                    Body = "Customer's email: " + model.FromEmail + "\n" + "Message: " + body
                })
                {
                    smtp.Send(mess);
                }

            }
            return RedirectToAction("Email", "Contact", new { email = model.FromEmail, name = model.FromName });
        }


    }
}