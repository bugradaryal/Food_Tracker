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




    }
}
