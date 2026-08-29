using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SchoolProject.Data.Helper;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;

        public EmailService(IOptions<MailSettings> options)
        {
            _mailSettings = options.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var email = new MimeMessage();

            email.From.Add(
                new MailboxAddress(
                _mailSettings.DisplayName,
                _mailSettings.Mail));

            email.To.Add(MailboxAddress.Parse(to));

            email.Subject = subject;

            email.Body = new TextPart("html")
            {
                Text = body
            };

            using var smtp = new SmtpClient();

            try
            {
                await smtp.ConnectAsync(
               _mailSettings.Host,
               _mailSettings.Port,
               SecureSocketOptions.StartTls);

                await smtp.AuthenticateAsync(
                    _mailSettings.UserName,
                    _mailSettings.Password);

                await smtp.SendAsync(email);

            }
            finally
            {
                await smtp.DisconnectAsync(true);
            }

        }
    }
}
