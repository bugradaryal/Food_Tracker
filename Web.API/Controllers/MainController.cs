using Microsoft.AspNetCore.Mvc;
using System;
using Entities;
using Business.Abstract;
using Business.Concrete;

namespace Web.API.Controllers
{
    public class MainController : Controller
    {
        private IUserService _userService;
        public MainController()
        {
            _userService = new UserManager();
            ViewBag.error = string.Empty;
        }

        [HttpPost]
        public IActionResult MainScreen(int id)
        {
            User User = _userService.GetUserById(id);
            return View("MainScreen", User);
        }


        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public IActionResult About(int id2)
        {
            User User = _userService.GetUserById(id2);
            return View(User);
        }

        public IActionResult ContactUs()
        {
            return View();
        }

    }
}
