using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Entities;

namespace BackgroundJob.Managers
{
    public class Email
    {
        public void SendEmail(User User)
        {
            var message = new MimeMessage();
            var builder = new BodyBuilder
            {
                HtmlBody = string.Format
                (
                    @"<b>Eposta Adresiniz: </b> " + User.Eposta
                )
            };

            message.From.Add(MailboxAddress.Parse("bugraverify@gmail.com"));
            message.To.Add(MailboxAddress.Parse(User.Eposta));
            message.Subject = "Şifre hatırlatma Bilgileri.";
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                client.Authenticate("bugraverify@gmail.com", "31082000B");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
