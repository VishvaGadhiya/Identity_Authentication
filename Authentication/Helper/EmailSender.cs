using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace Authentication.Helper
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("AppName", "koby.jerde76@ethereal.email"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = htmlMessage };
            message.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync("koby.jerde76@ethereal.email", "1RZMgEvwnaUEDkPhwG");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}