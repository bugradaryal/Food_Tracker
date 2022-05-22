using Business.Abstract;
using Business.Concrete;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Web.API.Models;

namespace Web.API.Controllers
{
    public class NotificationController : Controller
    {
        private IUserService _userService;
        private INotificationService _notificationService;
        private INotification_CountService _notificationCountService;
        public NotificationController()
        {
            _userService = new UserManager();
            _notificationService = new NotificationManager();
            _notificationCountService = new Notification_CountManager();
            ViewBag.error = string.Empty;
        }
        public IActionResult Notifications(ViewModels vm)
        {
            ViewBag.CurrentView = "MainScreen";
            vm.User = _userService.GetUserById(vm.User.id);
            vm.User.Notification = _notificationService.GetNotificationsByUserId(vm.User.id);
            var notify = _notificationCountService.GetNotificationsCountByUserId(vm.User.id);
            if (notify != null)
            {
                if (notify.notificationscount != vm.User.Notification.Count)
                    vm.User.Notification_Count = _notificationCountService.UpdateNotificationByNotifi(new Notification_Count { user_id = vm.User.id, notificationscount = vm.User.Notification.Count });
                else
                    vm.User.Notification_Count = notify;
            }
            else
            {
                vm.User.Notification_Count = _notificationCountService.CreateNotificationCount(new Notification_Count { user_id = vm.User.id, notificationscount = vm.User.Notification.Count});
            }
            return View("Notification",vm);
        }
        public IActionResult DeleteNotifications(ViewModels vm)
        {
            ViewBag.CurrentView = "MainScreen";
            _notificationService.DeleteNotificationsById(vm.Notification_id);
            vm.User = _userService.GetUserById(vm.User.id);
            vm.User.Notification = _notificationService.GetNotificationsByUserId(vm.User.id);
            vm.User.Notification_Count = _notificationCountService.UpdateNotificationByNotifi(new Notification_Count { user_id = vm.User.id, notificationscount = vm.User.Notification.Count });
            if (vm.User.Notification_Count.notificationscount < vm.User.Notification.Count)
            {
                vm.User.Notification_Count = _notificationCountService.UpdateNotificationByNotifi(new Entities.Notification_Count { user_id = vm.User.id, notificationscount = vm.User.Notification.Count });
            }

            return View("Notification", vm);
        }
    }
}
