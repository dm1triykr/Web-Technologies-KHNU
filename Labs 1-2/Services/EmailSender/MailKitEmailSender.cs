using MailKit.Net.Smtp;
using MimeKit;
//using SendGrid;
//using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Services.EmailSender
{
    public class MailKitEmailSender : IEmailSender
    {
        public async Task SendMessage(string emailTo, string messageBody, string subject)
        {
            MimeMessage emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "dimonk601@gmail.com"));
            emailMessage.To.Add(new MailboxAddress(emailTo));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("Plain")
            {
                Text = messageBody
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("dimonk601@gmail.com", "****");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
