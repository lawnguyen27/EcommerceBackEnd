using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace ShopLibrary.Service
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService()
        {
        }

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = int.Parse("587"),
                Credentials = new NetworkCredential(
                    "teamoshoes27@gmail.com",
                    "tqzn qlhs sfnt zgzm"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("teamoshoes27@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            smtpClient.UseDefaultCredentials = false;

            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
