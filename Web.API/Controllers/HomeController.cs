using Microsoft.AspNetCore.Mvc;
using System;
using Entities;
using Business.Abstract;
using Business.Concrete;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Web.API.Models;

namespace Web.API.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private INotificationService _notificationService;
        private INotification_CountService _notificationCountService;
        public HomeController()
        {
            _userService = new UserManager();
            _notificationService = new NotificationManager();
            _notificationCountService = new Notification_CountManager();
            ViewBag.error = string.Empty;
        }
        public IActionResult Index() //homepage
        {
            ViewBag.CurrentView = "AnaSayfa";
            return View();
        }
        public IActionResult About()
        {
            ViewBag.CurrentView = "About";
            return View();
        }
        public IActionResult ContactUs()
        {
            ViewBag.CurrentView = "ContactUs";
            return View();
        }

        #region giriş işlemleri

        public IActionResult Login()
        {
            ViewBag.CurrentView = "Login";
            return View();
        }
        [HttpPost]
        public IActionResult Login_User(User UserView)
        {
            ViewBag.CurrentView = "Login";
            try
            {
                User User = _userService.GetUserByEmail(UserView.Eposta);
                if(User != null)
                {
                    if (User.Sifre == UserView.Sifre)
                    {
                        ViewBag.CurrentView = "MainScreen";
                        ViewModels vm = new ViewModels();
                        vm.User = User;
                        vm.User.Notification = _notificationService.GetNotificationsByUserId(User.id);
                        vm.User.Notification_Count = _notificationCountService.GetNotificationsCountByUserId(User.id);
                        return View("../Main/MainScreen", vm);
                    }
                    else
                    {
                        ViewBag.error = "Şifre veya eposta adresi hatalı.";
                        return View("Login");
                    }
                }
                else
                {
                    ViewBag.error = "Böyle bir hesap bulunamadı.";
                    return View("Login");
                }
            }
            catch (Exception ht) { return Content("Http Get 404 Error!!! Code: "+ht.ToString().Substring(1,600)); }
        }
        #endregion

        #region üye olma işlemleri

        public IActionResult Register()
        {
            return View();
        }

        public int Random_fonksiyon()
        {
            Random random = new Random();
            int rand_sayı = random.Next(10000, 99999); //doğrulama codu (5 haneli)
            return rand_sayı;
        }

        [HttpPost]
        public IActionResult Register_User(User UserView)
        {
            try
            {
                ViewBag.CurrentView = "Verification";

                if(_userService.UserAny(UserView.Eposta) == false)
                {

                    int random_sayı_tut = Random_fonksiyon();

                    var message = new MimeMessage();
                    var builder = new BodyBuilder
                    {
                        HtmlBody = string.Format
                        (
                            @"<b>Doğrulama Kodunuz: </b> " + random_sayı_tut +
                            @"<p>Bizi Tercih Ettiğiniz İçin teşekkür ederiz. </p>"
                        )
                    };

                    message.From.Add(MailboxAddress.Parse("bugraverify@gmail.com"));
                    message.To.Add(MailboxAddress.Parse(UserView.Eposta.ToString()));
                    message.Subject = "Doğrulama Kodu.";
                    message.Body = builder.ToMessageBody();

                    using (var client = new SmtpClient())
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                        client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                        client.Authenticate("bugraverify@gmail.com", "zsjiwsyvetnnrwrg");

                        client.Send(message);
                        client.Disconnect(true);
                    }

                    TempData["verifycode"] = random_sayı_tut;


                    return View("Verification", UserView);
                }
                else
                {
                    ViewBag.error = "Eposta adresi kullanılmış!";
                    return View("Register");
                }
            }
            catch (Exception ht) { return Content("Http Get 404 Error!!! Code: " + ht.ToString().Substring(1, 600)); }
        }

        [HttpPost]
        public IActionResult Verification(string verifi, string ad, string soyad, string sifre, string eposta, string Cinsiyet)
        {
            string verifycode;
            try
            {
                if(TempData["verifycode"]  != null)
                    verifycode = TempData["verifycode"].ToString();
                else
                    return Content("Http Get 404 Error!!! - Tempdata verification error");
                User UserView = new User { Ad = ad, Soyad = soyad, Eposta = eposta, Sifre = sifre, Cinsiyet= Cinsiyet };
                if (verifycode == verifi)
                {
                    _userService.CreateUser(UserView);
                    ViewBag.error = "Yeni Hesap Oluşturuldu!";
                    return View("Login");
                }
                else
                {
                    ViewBag.error = "Doğrulama Kodu Yanlış!";
                    TempData["verifycode"] = verifycode;
                    return View(UserView);
                }
            }
            catch (Exception ht) { return Content("Http Get 404 Error!!! Code: " + ht.ToString().Substring(1, 600)); }
        }
        #endregion

        #region şifre hatırlatma epostası işlemleri
        public IActionResult ForgotPass()
        {
            ViewBag.CurrentView = "ForgotPassword";
            return View();
        }


        public IActionResult ForgotPass_form(string eposta)
        {
            ViewBag.CurrentView = "ForgotPassword";
            try
            {
                User User = _userService.GetUserByEmail(eposta);
                if(User != null)
                {
                    var message = new MimeMessage();
                    var builder = new BodyBuilder
                    {
                        HtmlBody = string.Format
                        (
                            @"<b>Eposta Adresiniz: </b> " + User.Eposta +

                            @"<br/><b>Şifreniz: </b> " + User.Sifre +

                            @"<p>Şifrenizi değiştirmek istiyorsanız. Giriş yaptıktan sonra 'Profile (Profilim)' sayfasından bilgilerinizi güncelleyebilirsiniz. <br/></p>" +

                             @"<p>Bizi Tercih Ettiğiniz İçin teşekkür ederiz.</p>"
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
                        client.Authenticate("bugraverify@gmail.com", "zsjiwsyvetnnrwrg");

                        client.Send(message);
                        client.Disconnect(true);
                    }
                    ViewBag.CurrentView = "ForgotPasswordSend";
                    return View("ForgotPassSend", "<p style='margin-left:1em;'><b style='color:white'>Şifre hatırlatma epostası gönderilmiştir.</b><br/><b style='color: yellow;'>  Lütfen spam kutunuzu kontrol etmeyi unutmayınız..</b></p>");
                }
                else
                {
                    ViewBag.error = "Böyle bir hesap bulunamadı.";
                    return View("ForgotPass");
                }
            }
            catch (Exception ht) { return Content("Http Get 404 Error!!! Code: " + ht.ToString().Substring(1, 600)); }
        }
        #endregion
    }
}
