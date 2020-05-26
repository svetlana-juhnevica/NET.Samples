using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebShop.Extensions;
using MyWebShop.Logic;
using MyWebShop.Models;

namespace MyWebShop.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            var model = new UserModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if(ModelState.IsValid)
                //vai paroles sakrit
                //vai lietiotajs ar tadu pastu neeksiste
            {
                if(model.Password != model.PasswordRepeat)
                {
                    ModelState.AddModelError("pass", "Passwords do not match!");
                }
                else
                {
                    UserModel user = UserManager.GetByEmail(model.Email).ToModel();
                    if(user != null)
                    {
                        ModelState.AddModelError("mail", "User with this e-mail already exists!");
                    }
                    else
                    {
                        UserManager.Create(model.Email, model.Name, model.Password);
                        return RedirectToAction(nameof(SignIn));
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            var model = new LoginModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult SignIn(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                //todo: lietotja atlase no db pec pasts un paroles,izmantojot UserManager
                UserModel user = UserManager.GetByEmailAndPassword(model.Email, model.Password).ToModel();
                if(user ==null)
                {
                    ModelState.AddModelError("user", "Invalid e-mail/password!");
                }
                else
                {
                    //todo: saglabā lietotāja dtus sesijā
                    HttpContext.Session.SetUserName(user.Name);
                    HttpContext.Session.SetUserId(user.Id);
                    HttpContext.Session.SetIsAdmin(user.IsAdmin);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult MyCart()
        {
            //veikc lietotaja groza atlasi no DB, izmantojot UserCartManager
            //attelo lietotaja groza saturu
            var userCart = UserCartManager.GetByUser(HttpContext.Session.GetUserId());
           //attelosanai niepieciesamas tikai preces
            var items = userCart.Select(c => c.Item.ToModel()).ToList();
            return View(items);
        }
        public IActionResult Confirm()
        {
            UserCartManager.DeleteAll();
            
            ViewData["Confirm"] = "Your order has been processed";
            return View();
          
           
        }
        public IActionResult DeleteFromCart (int id)
        {
            var itemId = id;
            UserCartManager.DeleteFromCart(itemId);
            return RedirectToAction(nameof(MyCart));

        }
        

    }
}