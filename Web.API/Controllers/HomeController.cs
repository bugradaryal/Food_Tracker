using Microsoft.AspNetCore.Mvc;
using System;
using Entities;
using Business.Abstract;
using Business.Concrete;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Web.API.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        public HomeController()
        {
            _userService = new UserManager();
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
        public ActionResult Login()
        {
            ViewBag.CurrentView = "Login";
            return View();
        }
        [HttpPost]
        public IActionResult Login_User(User UserView)
        {
            try
            {
                User User = _userService.GetUserByEmail(UserView.Eposta);
                ViewBag.CurrentView = "Login";
                if(User != null)
                {
                    if (User.Sifre == UserView.Sifre)
                    {
                        ViewBag.CurrentView = "MainScreen";
                        User mainuser = _userService.GetUserById(User.id); //verileri tam çekiyoruz ve yolluyoruz
                        return View("../Main/MainScreen", mainuser);
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
            catch (Exception ht) { return Content("Http Get 404 Error!!! Code: "+ht.ToString().Substring(0,600)); }
        }

        public IActionResult Register()
        {
            return View();
        }


        #region üye olma işlemleri

        public int random_fonksiyon()
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

                int random_sayı_tut = random_fonksiyon();

                var message = new MimeMessage();
                var builder = new BodyBuilder();

                builder.HtmlBody = string.Format
                    (
                        @"<b>Doğrulama Kodunuz: </b> " + random_sayı_tut +
                        @"<p>Bizi Tercih Ettiğiniz İçin teşekkür ederiz. <br/></p>"
                    );

                message.From.Add(MailboxAddress.Parse("bugraverify@gmail.com"));
                message.To.Add(MailboxAddress.Parse(UserView.Eposta.ToString()));
                message.Subject = "Doğrulama Kodu.";
                message.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                    client.Authenticate("bugraverify@gmail.com", "31082000B");

                    client.Send(message);
                    client.Disconnect(true);
                }

                TempData["verifycode"] = random_sayı_tut;


                return View("Verification", UserView);
            }
            catch (Exception ht) { return Content("Http Get 404 Error!!! Code: " + ht.ToString().Substring(0, 600)); }
        }

        string verifycode;

        [HttpPost]
        public IActionResult Verification(string verifi, string ad, string soyad, string sifre, string eposta)
        {
            try
            {
                if(TempData["verifycode"]  != null)
                    verifycode = TempData["verifycode"].ToString();
                else
                    return Content("Http Get 404 Error!!! - Tempdata verification error");
                User UserView = new User { Ad = ad, Soyad = soyad, Eposta = eposta, Sifre = sifre };
                if (verifycode == verifi)
                {
                    _userService.CreateUser(UserView);
                    return View("Login");
                }
                else
                {
                    ViewBag.error = "Doğrulama Kodu Yanlış!";
                    TempData["verifycode"] = verifycode;
                    return View(UserView);
                }
            }
            catch (Exception ht) { return Content("Http Get 404 Error!!! Code: " + ht.ToString().Substring(0, 600)); }
        }


        #endregion
    }
}
