using Microsoft.AspNetCore.Mvc;
using Programowanie_ASP_NET_CORE_MVC.DbServices;
using Programowanie_ASP_NET_CORE_MVC.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Programowanie_ASP_NET_CORE_MVC.ViewModels;

namespace Programowanie_ASP_NET_CORE_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {

                    HttpContext.Session.SetInt32("UserId", user.Id);
                    return RedirectToAction("Index", "Cars"); 
                }
                else
                {
                    ModelState.AddModelError("", "Błędne dane logowania");
                }
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (_context.Users.Any(u => u.Username == model.Username))
                {
                    ModelState.AddModelError("Username", "Użytkownik o podanej nazwie już istnieje");
                    return View(model);
                }


                var newUser = new User
                {
                    Username = model.Username,
                    Password = model.Password
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();


                HttpContext.Session.SetInt32("UserId", newUser.Id);
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        public IActionResult Logout()
        {

            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Index", "Home"); 
        }
    }
}
