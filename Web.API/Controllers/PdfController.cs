using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Entities;
using Web.API.Models;
using Business.Abstract;
using Business.Concrete;
using System.Collections.Generic;

namespace Web.API.Controllers.Pdf
{
    public class PdfController : Controller
    {
        private IFridgeService _fridgeService;
        private IMy_FoodService _my_FoodService;
        private IFoodService _foodService;
        public PdfController()
        {
            _fridgeService = new FridgeManager();
            _my_FoodService = new My_FoodManager();
            _foodService = new FoodManager();
        }
       public IActionResult Pdf(ViewModels vm)
        {
            vm.name = _fridgeService.GetFridgeById(vm.Fridge_id).name;
            vm.My_Food = _my_FoodService.GetAllMy_Foods(vm.Fridge_id);
            foreach (var x in vm.My_Food)
            {
               x.Food = _foodService.GetFoodById(x.Foods_id);
            }

            return new ViewAsPdf("Pdf", vm)
            {
                PageMargins = { Bottom = 20, Right = 20, Top = 20 },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                PageSize = Rotativa.AspNetCore.Options.Size.A3,
            };
        }
    }
}