using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Database;
using MyFirstWebApp.Models;

namespace MyFirstWebApp.Controllers
{
    public class CategoryController : Controller
    {
        public static List<CategoryModel> Categories = new List<CategoryModel>();
           
        public IActionResult Index()
        {
            
            using (var db = new Database.DB())
            {
              var model = db.Categories.OrderBy(c => c.Name).
                    Select(c=> new CategoryModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                    })
                    .ToList();  
                return base.View(model);
            }
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CategoryModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            if(ModelState.IsValid)
            {
                using (var db = new Database.DB())
                {
                    db.Categories.Add(new Database.Categories()
                    {
                        Name = model.Name,
                    });
                    db.SaveChanges();
                      
                }
                   
            return RedirectToAction(nameof(Index));
        }
            return View(model);
        }
    }
}