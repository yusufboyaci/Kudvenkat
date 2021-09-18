using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kudvenkat.Models
{
    public class SmtpParameters
    {
        public string SenderMail { get; set; }
        public string SenderPass { get; set; } = "Password";
        public ArrayList MailTo { get; set; }
        public string Subject { get; set; }
        public bool IsHtml { get; set; }
        public string Body { get; set; }
        public string SmtpHost { get; set; } = "smtp.gmail.com";
        public int Port { get; set; } = 587;
    }
}
