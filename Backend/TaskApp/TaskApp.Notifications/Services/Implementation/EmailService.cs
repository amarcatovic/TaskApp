using System;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using MimeKit.Text;
using TaskApp.Notifications.Utilities.Email;
using TaskApp.Notifications.Utilities.Email.HTML;

namespace TaskApp.Notifications.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly MimeMessage _mail;
        private readonly IOptions<EmailSettings> _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings;
            _mail = new MimeMessage();
            _mail.From.Add(new MailboxAddress(_emailSettings.Value.FromName, _emailSettings.Value.From));
        }

        public async Task<bool> SendTaskCreatedEmailAsync(string to, string subject, string body, DateTime finishDate, bool isHTML = true)
        {
            _mail.To.Add(new MailboxAddress("Reciever", to));
            _mail.Subject = subject;


            if (isHTML)
            {
                _mail.Body = new TextPart(TextFormat.Html) { Text = TaskCreatedEmailTemplate.TaskActivationEmailTemplate(body, finishDate) };
            }

            else
            {
                _mail.Body = new TextPart("plain") { Text = body };
            }

            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, false);
                    await client.AuthenticateAsync(_emailSettings.Value.From, _emailSettings.Value.Password);
                    await client.SendAsync(_mail);
                    await client.DisconnectAsync(true);
                }

                return true;
            }
            catch (SmtpException exception)
            {
                System.Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}
