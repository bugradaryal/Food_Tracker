using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using Entities;
using Web.API.Models;

namespace Web.API.Controllers
{
    public class MainController : Controller
    {
        private IUserService _userService;
        private IFridgeService _fridgeService;
        private IMy_FoodService _my_FoodService;
        private INotificationService _notificationService;
        public MainController()
        {
            _userService = new UserManager();
            _fridgeService = new FridgeManager();
            _my_FoodService = new My_FoodManager();
            _notificationService = new NotificationManager();
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
            vm.User = _userService.GetUserById(vm.User.id);
            return View(vm);
        }

        [HttpPost]
        public IActionResult ContactUs(ViewModels vm)
        {
            ViewBag.CurrentView = "ContactUs";
            vm.User = _userService.GetUserById(vm.User.id);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Fridge(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Fridge";
                User user = _userService.GetUserById(vm.User.id);
                if (_fridgeService.GetAllFridgesByUserId(user.id).Count == 0)
                {
                    _fridgeService.CreateFridge(new Entities.Fridge { user_id = user.id});
                    ViewBag.error = "Bir buzdolabın olmadığını farkettik ve senin için yeni bir tane oluşturduk.";
                }

                Fridge fr = _fridgeService.GetFirstFridgeByUserId(user.id);

                vm.User = user;
                vm.Fridge=  _fridgeService.GetAllFridgesByUserId(user.id);
                vm.id = fr.id;
                vm.name = fr.name;
                vm.My_Foods = _my_FoodService.GetAllMy_Foods(fr.id);

                return View(vm);
            }
            catch(Exception error)
            {
                return Content("Buzdolabına giriş yapılırken bir hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }


        [HttpPost]
        public IActionResult Fridge_Select(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Fridge";
                User user = _userService.GetUserById(vm.User.id);

                vm.User = user;
                vm.Fridge = _fridgeService.GetAllFridgesByUserId(user.id);

                Fridge fr = _fridgeService.GetFridgeById(vm.id);

                vm.id = fr.id;
                vm.name = fr.name;
                vm.My_Foods = _my_FoodService.GetAllMy_Foods(fr.id);
                ViewBag.error = "Buzdolabı değiştirildi.";
                return View("Fridge",vm);
            }
            catch (Exception error)
            {
                return Content("Buzdolabında değişiklik yapılırken hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }


        [HttpPost]
        public IActionResult Fridge_Delete(ViewModels vm)
        {
            try
            {
                ViewData.Clear();
                ViewBag.CurrentView = "Fridge";
                User user = _userService.GetUserById(vm.User.id);
                _fridgeService.DeleteFridge(vm.id); //silme işlemi

                ViewBag.error = "Silme İşlemi Gerçekleştirildi.   "; // alttaki viewbag çalışırsa üzerine yazacak!!!

                if (_fridgeService.GetAllFridgesByUserId(user.id).Count == 0)
                {
                    _fridgeService.CreateFridge(new Entities.Fridge { user_id = user.id });
                    ViewBag.error += "Bir buzdolabın olmadığını farkettik ve senin için yeni bir tane oluşturduk.";
                }

                Fridge fr = _fridgeService.GetFirstFridgeByUserId(user.id);

                vm.User = user;
                vm.Fridge = _fridgeService.GetAllFridgesByUserId(user.id);
                vm.id = fr.id;
                vm.name = fr.name;
                vm.My_Foods = _my_FoodService.GetAllMy_Foods(fr.id);

                return View("Fridge",vm);
            }
            catch (Exception error)
            {
                return Content("Buzdolabında silme işlemi yapılırken bir hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }
        [HttpPost]
        public IActionResult Fridge_Create(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Fridge";
                User user = _userService.GetUserById(vm.User.id);
                Fridge fr = _fridgeService.CreateFridge(new Entities.Fridge { user_id = user.id });

                vm.User = user;
                vm.Fridge = _fridgeService.GetAllFridgesByUserId(user.id);
                vm.id = fr.id;
                vm.name = fr.name;
                //my_food olmayacak burada, yeni oluşturulan bi dolap zaten boştur.
                ViewBag.error = "Yeni Buzdolabı Oluşturuldu..";
                return View("Fridge", vm);
            }
            catch(Exception error)
            {
                return Content("Buzdolabı oluşturma işlemi yapılırken bir hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Fridge_Rename(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Fridge";
                User user = _userService.GetUserById(vm.User.id);
                
                vm.User = user;
                string old_name = _fridgeService.GetFridgeById(vm.id).name;
                _fridgeService.UpdateFridge(new Fridge { id = vm.id, name = vm.name, user_id = user.id});
                vm.Fridge = _fridgeService.GetAllFridgesByUserId(user.id);

                vm.My_Foods = _my_FoodService.GetAllMy_Foods(vm.id);


                ViewBag.error = "\"" + old_name+ "\" Adlı buzdolabı \"" + vm.name.ToString() + "\" Olarak Yeniden Adlandırıldı..";
                return View("Fridge", vm);
            }
            catch (Exception error)
            {
                return Content("Buzdolabı oluşturma işlemi yapılırken bir hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }



        [HttpPost]
        public IActionResult Account(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Account";
                vm.User = _userService.GetUserById(vm.User.id);
                if (_notificationService.GetUsersNotifications(vm.User.id) == null)
                {
                    vm.Notification = _notificationService.CreateNotification(new Notification { user_id = vm.User.id });
                }
                else
                {
                    vm.Notification = _notificationService.GetUsersNotifications(vm.User.id);
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
                _userService.DeleteUser(vm.User.id);
                ViewBag.error = "Kullanıcı hesabı silindi.";
                return View("../Home/Login");
            }
            catch(Exception error)
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
                vm.Notification = _notificationService.GetUsersNotifications(vm.User.id);

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
                _userService.UpdateUser(vm.User);
                ViewBag.error = "Hesap bilgileri güncellendi.";
                vm.Notification = _notificationService.GetUsersNotifications(vm.User.id);
                return View("Account",vm);
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
                if(vm.Notification.tercih_sms == true)
                {
                    if (vm.User.Telefon == null || vm.User.Telefon == string.Empty)
                    {
                        vm.Notification.tercih_sms = false;

                        ViewBag.error = "Sms için telefon numaranızı tanımlayınız. ";
                    }
                }

                ViewBag.error += "Bildirim Güncelleme İşlemi Tamamlandı.";
                vm.Notification.user_id = vm.User.id;
                _notificationService.UpdateNotification(vm.Notification);
                return View("Account", vm);
            }
            catch (Exception error)
            {
                return Content("Bildirim işlemi gerçekleştirilirken bir hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }
    }
}
