using HomeManagement.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly EmailConfiguration emailConfig;

        public EmailServices(EmailConfiguration emailConfig)
        {
            this.emailConfig = emailConfig;
        }

        public async Task SendEmailAsync(MailMessage message)
        {
            var createdMessage = CreateMessage(message);

            await SendMessageAsync(createdMessage);
        }

        private MimeMessage CreateMessage(MailMessage message)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("HomeManagementApp", emailConfig.From));
            email.To.AddRange(message.Recepients);
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = String.Format(message.Subject, message.Body) };
            email.Date = DateTime.Now;

            return email;
        }

        private async Task SendMessageAsync(MimeMessage createdMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(emailConfig.SmtpServer, emailConfig.Port, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(emailConfig.From, emailConfig.Password);
                    await client.SendAsync(createdMessage);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
