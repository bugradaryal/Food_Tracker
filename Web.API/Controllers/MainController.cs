using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Mvc;
using Web.API.Models;

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
        public IActionResult MainScreen(ViewModels vm)
        {
            ViewBag.CurrentView = "Kullanıcı_AnaSayfa";
            vm.User = _userService.GetUserById(vm.User.id);
            return View("MainScreen", vm);
        }

        [HttpPost]
        public IActionResult About(ViewModels vm)
        {
            ViewBag.CurrentView = "About";
            return View(vm);
        }

        [HttpPost]
        public IActionResult ContactUs(ViewModels vm)
        {
            ViewBag.CurrentView = "ContactUs";
            return View(vm);
        }
    }
}
