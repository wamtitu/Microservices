using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailingServices.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace MailingServices.Services
{
    public class SendEmailServices
    {
        private readonly string email ;
        private readonly string password;
        public SendEmailServices(IConfiguration _configuration)
        {
            
             email = _configuration.GetSection("EmailService:Email").Get<string>();
             password = _configuration.GetSection("EmailService:Password").Get<string>();
        }
         public async Task SendEmail(UserMessage res, string message)
        {
            MimeMessage message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("The post blog",email));

            // Set the recipient's email address
            message1.To.Add(new MailboxAddress(res.Name, res.Email));

            message1.Subject = "successfully created your account";

            var body = new MimeKit.TextPart("html")
            {
                Text = message.ToString()
            };
            message1.Body = body;

            var client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);

            client.Authenticate(email, password);

            await client.SendAsync(message1);

            await client.DisconnectAsync(true);
        }
    }
}