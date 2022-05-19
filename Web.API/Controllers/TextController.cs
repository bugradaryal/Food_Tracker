using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using Entities;
using Web.API.Models;
using System.Collections.Generic;
using System.IO;

namespace Web.API.Controllers
{
    public class TextController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
