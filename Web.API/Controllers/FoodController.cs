using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using Entities;
using Web.API.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Web.API.Controllers
{
    public class FoodController : Controller
    {
        private IFridgeService _fridgeService;
        private IMy_FoodService _my_FoodService;
        private IFoodService _foodService;
        public FoodController()
        {
            _fridgeService = new FridgeManager();
            _my_FoodService = new My_FoodManager();
            _foodService = new FoodManager();
            ViewBag.error = string.Empty;
        }
        [HttpPost]
        public IActionResult Foods(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Foods";
                vm.Food = _foodService.GetAllFoods();


                return View(vm);
            }
            catch (Exception error)
            {
                return Content("Yemekler sayfası açılırken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Food_AddToFridge(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Foods add";

                vm.Fridge = _fridgeService.GetAllFridgesByUserId(vm.User.id);
                List<Food> foods = new List<Food>();
                foods.Add(_foodService.GetFoodById(vm.Food_id));
                vm.Food = foods;


                return View(vm);
            }
            catch (Exception error)
            {
                return Content("Yemek ekleme sayfası açılırken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }


        [HttpPost]
        public IActionResult Food_Add(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Foods add";

                var food = _foodService.GetFoodById(vm.Food_id);
                var eklenme_tarihi = DateTime.Now;
                var bozulma_tarihi = eklenme_tarihi.AddDays(food.gün_bozulma_tarihi);
                if (_my_FoodService.GetMy_FoodByFoodId(vm.Fridge_id, vm.Food_id) == true)
                {
                    ViewBag.error ="\"" + food.yemek_ismi + "\" adlı yemek güncellendi.";
                    
                    _my_FoodService.UpdateMy_Food(new My_Food { Fridges_id = vm.Fridge_id, Foods_id = vm.Food_id, eklenme_tarihi = eklenme_tarihi, bozulma_tarihi = bozulma_tarihi });
                }
                else
                {
                    _my_FoodService.CreateMy_Food(new My_Food { Fridges_id = vm.Fridge_id, Foods_id = vm.Food_id, eklenme_tarihi = eklenme_tarihi, bozulma_tarihi = bozulma_tarihi });
                    ViewBag.error = "\"" + _foodService.GetFoodById(vm.Food_id).yemek_ismi + "\" adlı yemek eklendi.";
                }
                vm.Food = _foodService.GetAllFoods();
                return View("Foods", vm);
            }
            catch (Exception error)
            {
                return Content("Yemek eklenirken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Food_Search(ViewModels vm, string isim)
        {
            try
            {
                ViewBag.CurrentView = "Foods Search";
                vm.Food = _foodService.SearchByname(isim);
                ViewBag.data = vm.Food;
                return View("Foods", vm);
            }
            catch (Exception error)
            {
                return Content("Yemek araması yapılırken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Food_Filter(ViewModels vm, string islem)
        {
            try
            {
                var data = _foodService.GetAllFoods();
                ViewBag.CurrentView = "Foods Search";

                if(TempData["tıklama"] == null || (bool)TempData["tıklama"] == false)
                {
                    TempData["tıklama"] = true;
                    vm.Food = _foodService.Filter(data, islem);
                }
                else if((bool)TempData["tıklama"] == true)
                {
                    TempData["tıklama"] = false;
                    List<Food> reverse = _foodService.Filter(data, islem);
                    vm.Food = Enumerable.Reverse(reverse).ToList();
                }

                return View("Foods", vm);
            }
            catch (Exception error)
            {
                return Content("Yemek araması yapılırken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }
    }
}
