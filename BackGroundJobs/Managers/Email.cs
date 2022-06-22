using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Entities;

namespace BackGroundJobs.Managers
{
    public class Email
    {
        public static void SendEmail(User User, Food myfood)
        {
            var message = new MimeMessage();
            var builder = new BodyBuilder
            {
                HtmlBody = string.Format
                (
                    @"<h3>Yemek takip sitesi</h3>" +
                    @"<p><b>Kullanıcı: </b>" + User.Ad + " " + User.Soyad + "</p>" +
                    @"<p><b>Eposta Adresiniz: </b>" + User.Eposta + "</p>" +
                    @"<h4><b><p style='color:red;'>" + myfood.yemek_ismi + "</p> Adlı yemeğinizin bozulmasına son 24 saat kalmıştır.</b></h4>"
                )
            };

            message.From.Add(MailboxAddress.Parse("bugraverify@gmail.com"));
            message.To.Add(MailboxAddress.Parse(User.Eposta));
            message.Subject = "Yemeğiniz Bozulmak Üzere";
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                client.Authenticate("bugraverify@gmail.com", "zsjiwsyvetnnrwrg");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
