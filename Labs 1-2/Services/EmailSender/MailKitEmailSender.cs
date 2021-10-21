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
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("dimonk601@gmail.com", "0974082653");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
            /*var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("admin@mycompany.com", "Администрация сайта");
            var subjectEmail = subject;
            var to = new EmailAddress(emailTo);
            var plainTextContent = messageBody;
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subjectEmail, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);*/
        }
    }
}
