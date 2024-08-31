using EX_MVC.Data;
using EX_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EX_MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext context;

        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var Employess = context.Employees.ToList();
            return View("Index" ,Employess);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create( Employee Emp)
        {
            context.Employees.Add(Emp);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Emp = context.Employees.Find(id);
            return View(Emp);   
        }

        [HttpPost]
        public IActionResult Edit(Employee Emp)
        {
            var Employee_DB = context.Employees.Find(Emp.Id);

            Employee_DB.Name = Emp.Name;
            Employee_DB.Password = Emp.Password;
            Employee_DB.Email = Emp.Email;

            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            // var Emp = context.Employees.FirstOrDefault(Emp => Emp.Id == id);
            var Emp = context.Employees.Find(id);
            context.Employees.Remove(Emp);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
