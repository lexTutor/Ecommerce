using System;
using System.Collections.Generic;
using System.Linq;
using MailKit;
using MimeKit;

namespace HomeManagement.Models
{
    public class MailMessage
    {
        public MailMessage(IEnumerable<string> recipients, string subject, string body)
        {
            this.Recepients = new List<MailboxAddress>();
                Recepients.AddRange(recipients.Select(recipient => MailboxAddress.Parse(recipient)));
            this.Subject = subject;
            this.Body = body;

        }
        public List<MailboxAddress> Recepients { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
