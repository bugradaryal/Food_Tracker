using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Entities;
using Business.Abstract;
using Business.Concrete;

namespace Web.API.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        public HomeController()
        {
            _userService = new UserManager();
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
        public IActionResult Login()
        {
            ViewBag.CurrentView = "Login";
            return View();
        }


    }
}
