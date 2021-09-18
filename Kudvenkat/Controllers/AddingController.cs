using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Kudvenkat.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kudvenkat.Controllers
{
    public class AddingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SmtpParameters input)
        {

            bool results = SendEMail(input.SenderMail,
                input.SenderPass,
                new ArrayList() { input.MailTo },
                input.Subject,
                input.IsHtml,
                input.Body,
                input.SmtpHost,
                input.Port);
            return Json(results);
        }
        public bool SendEMail(string smtpHost = "smtp.gmail.com", int port = 587, string senderMail, string senderPass, ArrayList mailToArr, string subject, bool isHtml, string body)
        {
            try
            {

                SmtpClient smtpClient = new SmtpClient(smtpHost, port);
                smtpClient.UseDefaultCredentials = false;// true;
                smtpClient.Credentials = new System.Net.NetworkCredential(senderMail, senderPass);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderMail);
                for (int i = 0; i < mailToArr.Count; i++)
                {
                    mail.To.Add(new MailAddress((string)mailToArr[i]));
                }
                mail.Subject = subject;
                //mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));
                mail.Body = body;
                mail.IsBodyHtml = isHtml;
                mail.Priority = MailPriority.Normal;

                smtpClient.Send(mail);

                return true;
            }
            catch
            {
                return false;

                // write exception on server log

            }

        }

    }
}