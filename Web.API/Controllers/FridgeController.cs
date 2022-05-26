using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using Entities;
using Web.API.Models;
using System.Collections.Generic;

namespace Web.API.Controllers
{
    public class FridgeController : Controller
    {
        private IFridgeService _fridgeService;
        private IMy_FoodService _my_FoodService;
        private IFoodService _foodService;
        public FridgeController() 
        {  
            _fridgeService = new FridgeManager();
            _my_FoodService = new My_FoodManager();
            _foodService = new FoodManager();
            ViewBag.error = string.Empty;
        }



        [HttpPost]
        public IActionResult Fridge(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Fridge";
                if (_fridgeService.GetAllFridgesByUserId(vm.User.id).Count == 0)
                {
                    _fridgeService.CreateFridge(new Entities.Fridge { user_id = vm.User.id });
                    ViewBag.error = "Bir buzdolabın olmadığını farkettik ve senin için yeni bir tane oluşturduk.";
                }

                Fridge fr;
                if (vm.Fridge_id == 0)
                {
                    fr = _fridgeService.GetFirstFridgeByUserId(vm.User.id);
                }
                else
                {
                    fr = _fridgeService.GetFridgeById(vm.Fridge_id);
                }

                vm.Fridge = _fridgeService.GetAllFridgesByUserId(vm.User.id);
                vm.Fridge_id = fr.id;
                vm.name = fr.name;
                if (vm.My_Food == null)
                {
                    vm.My_Food = _my_FoodService.GetAllMy_Foods(fr.id);
                    foreach (var x in vm.My_Food)
                    {
                        x.Food = _foodService.GetFoodById(x.Foods_id);
                    }
                }

                return View(vm);
            }
            catch (Exception error)
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
                vm.Fridge = _fridgeService.GetAllFridgesByUserId(vm.User.id);

                Fridge fr = _fridgeService.GetFridgeById(vm.Fridge_id);

                vm.Fridge_id = fr.id;
                vm.name = fr.name;
                if (vm.My_Food == null)
                {
                    vm.My_Food = _my_FoodService.GetAllMy_Foods(fr.id);
                    foreach (var x in vm.My_Food)
                    {
                        x.Food = _foodService.GetFoodById(x.Foods_id);
                    }

                }

                ViewBag.error = "Buzdolabı değiştirildi.";
                return View("Fridge", vm);
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
                var myfoodlist = _my_FoodService.GetMy_FoodByFridgeId(vm.Fridge_id);
                foreach(var x in myfoodlist)
                {
                    BackgroundJobs.Schedules.Notification.deletenotification(x.Jobs_id);
                }
                _fridgeService.DeleteFridge(vm.Fridge_id); //silme işlemi

                ViewBag.error = "Silme İşlemi Gerçekleştirildi.   "; // alttaki viewbag çalışırsa üzerine yazacak!!!

                if (_fridgeService.GetAllFridgesByUserId(vm.User.id).Count == 0)
                {
                    _fridgeService.CreateFridge(new Entities.Fridge { user_id = vm.User.id });
                    ViewBag.error += "Bir buzdolabın olmadığını farkettik ve senin için yeni bir tane oluşturduk.";
                }

                Fridge fr = _fridgeService.GetFirstFridgeByUserId(vm.User.id);

                vm.Fridge = _fridgeService.GetAllFridgesByUserId(vm.User.id);
                vm.Fridge_id = fr.id;
                vm.name = fr.name;
                if (vm.My_Food == null)
                {
                    vm.My_Food = _my_FoodService.GetAllMy_Foods(fr.id);
                    List<My_Food> My_Food = new List<My_Food>();
                    foreach (var x in vm.My_Food)
                    {
                        x.Food = _foodService.GetFoodById(x.Foods_id);
                    }
                }

                return View("Fridge", vm);
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
                Fridge fr = _fridgeService.CreateFridge(new Entities.Fridge { user_id = vm.User.id });
                vm.Fridge = _fridgeService.GetAllFridgesByUserId(vm.User.id);
                vm.Fridge_id = fr.id;
                vm.name = fr.name;
                //my_food olmayacak burada, yeni oluşturulan bi dolap zaten boştur.
                ViewBag.error = "Yeni Buzdolabı Oluşturuldu..";
                return View("Fridge", vm);
            }
            catch (Exception error)
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

                string old_name = _fridgeService.GetFridgeById(vm.Fridge_id).name;
                _fridgeService.UpdateFridge(new Fridge { id = vm.Fridge_id, name = vm.name, user_id = vm.User.id });
                vm.Fridge = _fridgeService.GetAllFridgesByUserId(vm.User.id);

                if (vm.My_Food == null)
                {
                    vm.My_Food = _my_FoodService.GetAllMy_Foods(vm.Fridge_id);
                    foreach (var x in vm.My_Food)
                    {
                        x.Food = _foodService.GetFoodById(x.Foods_id);
                    }

                }


                ViewBag.error = "\"" + old_name + "\" Adlı buzdolabı \"" + vm.name.ToString() + "\" Olarak Yeniden Adlandırıldı..";
                return View("Fridge", vm);
            }
            catch (Exception error)
            {
                return Content("Buzdolabı yeniden adlandırma işlemi yapılırken bir hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Fridge_Food_Delete(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Delete Food on Fridge";

                var deletedfood = _my_FoodService.DeleteMy_Food(vm.Myfood_id);

                BackgroundJobs.Schedules.Notification.deletenotification(deletedfood.Jobs_id);

                vm.Fridge = _fridgeService.GetAllFridgesByUserId(vm.User.id);
                vm.name = _fridgeService.GetFridgeById(vm.Fridge_id).name;

                if (vm.My_Food == null)
                {
                    vm.My_Food = _my_FoodService.GetAllMy_Foods(vm.Fridge_id);
                    foreach (var x in vm.My_Food)
                    {
                        x.Food = _foodService.GetFoodById(x.Foods_id);
                    }

                }

                ViewBag.error += "Yemek silme işlemi tamamlandı.";
                return View("Fridge", vm);
            }
            catch (Exception error)
            {
                return Content("Yemek Silme İşlemi yapılırken bir hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }
        [HttpPost]
        public IActionResult Fridge_Food_Detail(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Food details on Fridge";

                if (vm.My_Food == null)
                {
                    List<Food> vmfood = new List<Food>();
                    vmfood.Add(_foodService.GetFoodById(_my_FoodService.GetMy_FoodById(vm.Myfood_id).Foods_id));
                    vm.Food = vmfood;

                }
                return View(vm);
            }
            catch (Exception error)
            {
                return Content("Yemek detaylarına ulaşılırken bir hata ile karşılaşıldı...\n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Food_Detail_Pdf(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Food details on Fridge";

                vm.Fridge = _fridgeService.GetAllFridgesByUserId(vm.User.id);
                vm.name = _fridgeService.GetFridgeById(vm.Fridge_id).name;

                if (vm.Food == null)
                {
                    List<Food> food = new List<Food>();
                    foreach (var x in _my_FoodService.GetAllMy_Foods(vm.Fridge_id))
                    {
                        var y = _foodService.GetFoodById(x.Foods_id);
                        food.Add(y);
                    }
                    vm.Food = food;
                }

                return View(vm);
            }
            catch (Exception error)
            {
                return Content("Yemek detay pdf dosyası indirilirken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }
    }
}
