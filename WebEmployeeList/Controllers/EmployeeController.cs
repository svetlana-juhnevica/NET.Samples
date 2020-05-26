using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebEmployeeList.Models;

namespace WebEmployeeList.Controllers
{
    public class EmployeeController : Controller
    {
        public static List<EmployeeModel> Employees = new List<EmployeeModel>();

        public IActionResult Index()
        {

            var model = Employees.OrderBy(c => c.Surname).ThenBy(c=>c.Department).ToList();
            return View(model);
        }
        public IActionResult View(int id)
        {
            var employee = Employees.Find(u => u.Id == id);
            return View(employee);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new EmployeeModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Employees.Count + 1;
                Employees.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult DepartmentsView()
        {
             var model = Employees
                    .Select(std => std.Department)
                    .Distinct().ToList();
            return View(model);

        }
    }
}
