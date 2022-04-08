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

        [HttpPost]
        public IActionResult About(int id)
        {
            User User = _userService.GetUserById(id);
            return View(User);
        }

        [HttpPost]
        public IActionResult ContactUs(int id)
        {
            User User = _userService.GetUserById(id);
            return View(User);
        }

    }
}
