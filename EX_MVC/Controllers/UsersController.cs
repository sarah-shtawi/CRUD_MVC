using EX_MVC.Data;
using EX_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EX_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;

        public UsersController(ApplicationDbContext context )
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var users = context.Users.ToList();
            return View(users);
        }

        public IActionResult IsActive(User user)
        {
            var userDB = context.Users.Find(user.Id);
            userDB.IsActive = true;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Login));
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user) 
        {
            var CheackUser = context.Users.Where( userDB => userDB.Name == user.Name && userDB.Password == user.Password );
            if (CheackUser.Any())
            {
                return RedirectToAction(nameof(Index)); 
            }
            ViewBag.Error = "Invalid UserName / Password";
            return View(user);
        }
      



    }
}
