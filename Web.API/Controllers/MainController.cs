using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Mvc;
using Web.API.Models;

namespace Web.API.Controllers
{
    public class MainController : Controller
    {
        private IUserService _userService;
        private INotificationService _notificationService;
        private INotification_CountService _notificationCountService;
        public MainController()
        {
            _userService = new UserManager();
            _notificationService = new NotificationManager();
            _notificationCountService = new Notification_CountManager();
            ViewBag.error = string.Empty;
        }

        [HttpPost]
        public IActionResult MainScreen(ViewModels vm)
        {
            ViewBag.CurrentView = "MainScreen";
            vm.User = _userService.GetUserById(vm.User.id);
            vm.User.Notification = _notificationService.GetNotificationsByUserId(vm.User.id);
            vm.User.Notification_Count = _notificationCountService.GetNotificationsCountByUserId(vm.User.id);
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
