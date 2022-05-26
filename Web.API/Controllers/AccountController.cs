using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using Entities;
using Web.API.Models;
using System.Linq;

namespace Web.API.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private INotificationTypeService _notificationTypeService;
        private IFridgeService _fridgeService;
        private IMy_FoodService _my_foodService;

        public AccountController()
        {
            _my_foodService = new My_FoodManager();
            _fridgeService = new FridgeManager();
            _userService = new UserManager();
            _notificationTypeService = new NotificationTypeManager();
            ViewBag.error = string.Empty;
        }


        [HttpPost]
        public IActionResult Account(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Account";
                vm.User = _userService.GetUserById(vm.User.id);
                if (_notificationTypeService.GetUsersNotification(vm.User.id) == null)
                {
                    vm.NotificationType = _notificationTypeService.CreateNotification(new NotificationType { user_id = vm.User.id });
                }
                else
                {
                    vm.NotificationType = _notificationTypeService.GetUsersNotification(vm.User.id);
                }
                return View(vm);
            }
            catch (Exception error)
            {
                return Content("Hesaba giriş yapılırken hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Account_Delete(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Account Delete";

                var fridge_list = _fridgeService.GetAllFridgesByUserId(vm.User.id);
                foreach (var x in fridge_list)
                {
                    if (_my_foodService.GetMy_FoodByFridgeId(x.id).Any() == true)
                    {
                        foreach (var y in _my_foodService.GetMy_FoodByFridgeId(x.id))
                        {
                            BackgroundJobs.Schedules.Notification.deletenotification(y.Jobs_id);
                        }
                    }
                }

                _userService.DeleteUser(vm.User.id);

                ViewBag.error = "Kullanıcı hesabı silindi.";
                return View("../Home/Login");
            }
            catch (Exception error)
            {
                return Content("Hesap silinirken bir hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Account_Edit(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Account Edit";
                vm.User = _userService.GetUserById(vm.User.id);
                vm.NotificationType = _notificationTypeService.GetUsersNotification(vm.User.id);

                return View(vm);
            }
            catch (Exception error)
            {
                return Content("Hesap düzenleme sayfası açılırken hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Account_Edit_Post(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Account Edit";
                vm.NotificationType = _notificationTypeService.GetUsersNotification(vm.User.id);
                if (vm.NotificationType.tercih_sms == true)
                {
                    if (vm.User.Telefon == string.Empty || vm.User.Telefon == null)
                    {
                        vm.User.Telefon = _userService.GetUserById(vm.User.id).Telefon;
                        ViewBag.error = "Sms bildirim özelliği açıkken telefon numarası silinemez! ";
                    }
                }

                _userService.UpdateUser(vm.User);
                ViewBag.error += "Hesap bilgileri güncellendi.";
                return View("Account", vm);
            }
            catch (Exception error)
            {
                return Content("Hesap düzenleme işlemi kaydedilirken bir hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Notification(ViewModels vm)
        {
            try
            {
                ViewData.Clear();
                ViewBag.CurrentView = "Notification Edit";
                vm.User = _userService.GetUserById(vm.User.id);
                if (vm.NotificationType.tercih_sms == true)
                {
                    if (vm.User.Telefon == null || vm.User.Telefon == string.Empty)
                    {
                        vm.NotificationType.tercih_sms = false;

                        ViewBag.error = "Sms için telefon numaranızı tanımlayınız. ";
                    }
                }

                ViewBag.error += "Bildirim Güncelleme İşlemi Tamamlandı.";
                vm.NotificationType.user_id = vm.User.id;
                _notificationTypeService.UpdateNotification(vm.NotificationType);
                return View("Account", vm);
            }
            catch (Exception error)
            {
                return Content("Bildirim işlemi gerçekleştirilirken bir hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }




    }
}
