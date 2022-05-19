using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using Entities;
using Web.API.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Web.API.Controllers
{
    public class TextController : Controller
    {
        private IUser_articleService _user_articleService;
        private IUserService _userService;
        public TextController()
        {
            _userService = new UserManager();
            _user_articleService = new User_articleManager();
            ViewBag.error = string.Empty;
        }
        [HttpPost]
        public IActionResult Text(ViewModels vm)
        {
            ViewBag.CurrentView = "Text";
            try
            {
                vm.User_article = _user_articleService.GetAllUser_articles();
                foreach (var x in vm.User_article)
                {
                    x.User = _userService.GetUserById(x.user_id);
                }
                return View(vm);
            }
            catch (Exception error)
            {
                return Content("Yazı sayfası açılırken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Text_Search(ViewModels vm, string search)
        {
            try
            {
                ViewBag.CurrentView = "Text Search";
                if (_user_articleService.GetAllUser_articles().Any() == true)
                {
                    vm.User_article = _user_articleService.SearchByTitle(search);
                    foreach (var x in vm.User_article)
                    {
                        x.User = _userService.GetUserById(x.user_id);
                    }
                }
                return View("Text", vm);
            }
            catch (Exception error)
            {
                return Content("Yazı araması yapılırken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Text_Search_Clear(ViewModels vm)
        {
            ViewBag.CurrentView = "Text Search";
            try
            {
                vm.User_article = _user_articleService.GetAllUser_articles();
                foreach (var x in vm.User_article)
                {
                    x.User = _userService.GetUserById(x.user_id);
                }
                return View("Text", vm);
            }
            catch (Exception error)
            {
                return Content("Yazı araması temizlenirken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Text_New(ViewModels vm)
        {
            ViewBag.CurrentView = "My Text";
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create_New_Text(ViewModels vm, string title, string metin)
        {
            ViewBag.CurrentView = "Create New Text";
            try
            {
                _user_articleService.CreateUser_article(new User_article { user_id = vm.User.id, title = title, text = metin });
                vm.User_article = _user_articleService.GetAllUser_articles();
                foreach (var x in vm.User_article)
                {
                    x.User = _userService.GetUserById(x.user_id);
                }
                ViewBag.error = "Yazınız oluşturulmuştur. Yazılarım sayfanızdan kontrol edebilir ve düzenleyebilirsiniz.";
                return View("Text",vm);
            }
            catch (Exception error)
            {
                return Content("Yazı oluşturulurken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult My_Text(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "My Text";
                vm.User_article = _user_articleService.GetUser_ArticleByUserId(vm.User.id);
                return View(vm);
            }
            catch (Exception error)
            {
                return Content("Yazılarınız listelenirken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult My_Text_Delete(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "Text Delete";
                _user_articleService.DeleteUser_article(vm.User_article_id);
                vm.User_article = _user_articleService.GetUser_ArticleByUserId(vm.User.id);
                ViewBag.error = "Yazınız silinmiştir.";
                return View("My_Text", vm);
            }
            catch (Exception error)
            {
                return Content("Yazı silinirken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult My_Text_Search(ViewModels vm, string search)
        {
            try
            {
                ViewBag.CurrentView = "My Text Search";
                if (_user_articleService.GetUser_ArticleByUserId(vm.User.id).Any() == true)
                {
                    vm.User_article = _user_articleService.SearchByTitleForMyText(vm.User.id, search);
                }
                return View("My_Text", vm);
            }
            catch (Exception error)
            {
                return Content("Yazı araması yapılırken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult My_Text_Search_Clear(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "My Text";
                vm.User_article = _user_articleService.GetUser_ArticleByUserId(vm.User.id);
                return View("My_Text",vm);
            }
            catch (Exception error)
            {
                return Content("Yazı araması temizlenirken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult My_Text_Edit(ViewModels vm)
        {
            try
            {
                ViewBag.CurrentView = "My Text";
                List<User_article> userart = new List<User_article>();
                userart.Add(_user_articleService.GetUser_articleById(vm.User_article_id));
                vm.User_article = userart;
                return View(vm);
            }
            catch (Exception error)
            {
                return Content("Yazı araması temizlenirken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult My_Text_Edit_Save(ViewModels vm, string title, string metin)
        {
            try
            {
                ViewBag.CurrentView = "My Text";
                _user_articleService.UpdateUser_article(new User_article { id = vm.User_article_id, title = title, text = metin});
                vm.User_article = _user_articleService.GetUser_ArticleByUserId(vm.User.id);
                ViewBag.error = "Yazınız oluşturulmuştur.";
                return View("My_Text",vm);
            }
            catch (Exception error)
            {
                return Content("Yazı araması temizlenirken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }

        [HttpPost]
        public IActionResult Text_Read(ViewModels vm, string from)
        {
            try
            {
                ViewBag.CurrentView = "Text Read";
                ViewData["from"] = from;
                 List<User_article> userart = new List<User_article>();
                userart.Add(_user_articleService.GetUser_articleById(vm.User_article_id));
                vm.User_article = userart;
                foreach(var x in vm.User_article)
                {
                    x.User = _userService.GetUserById(x.user_id);
                }
                return View(vm);
            }
            catch (Exception error)
            {
                return Content("Yazılarınız listelenirken bir hata ile karşılaşıldı.. \n\n Hata:  " + error.ToString());
            }
        }
    }
}
