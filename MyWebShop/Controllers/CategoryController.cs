using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebShop.Extensions;
using MyWebShop.Logic.Managers;
using MyWebShop.Models;

namespace MyWebShop.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult List()
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                //return RedirectToAction("Index", "Home");
                return NotFound();
            }
            var categories = CategoryManager.GetAll().Select(u => u.ToModel()).ToList();
            return View(categories);
        }


        [HttpGet]
        public IActionResult Create()
        { 
             if(!HttpContext.Session.GetIsAdmin())
            {
                //return RedirectToAction("Index", "Home");
                return NotFound();
    }

            var model = new CategoryModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ParentId.HasValue)
                {
                    var category = CategoryManager.Get(model.ParentId.Value);
                    if (category == null)
                    {
                        ModelState.AddModelError("cat", "Category not found!");
                        return View(model);
                    }
                }
                CategoryManager.Create(model.Name, model.ParentId);
                return RedirectToAction(nameof(List));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CategoryManager.Delete(id);

            return RedirectToAction(nameof(List));
        }
    }
}
        
    

