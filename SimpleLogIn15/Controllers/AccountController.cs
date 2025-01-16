using Microsoft.AspNetCore.Mvc;
using SimpleLogIn15.Data;
using SimpleLogIn15.Models.ViewModels;
using SimpleLogIn15.Models;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace SimpleLogIn15.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(_context.Users);
        }
        public IActionResult Register()
        {
            ViewBag.Ro = new SelectList(_context.Roles, "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserViewModel reg)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = reg.UserName,
                    UserEmail = reg.UserEmail,
                    UserPassword = reg.UserPassword,
                    RoleId = reg.RoleId
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(LogIn));
            }
            ViewBag.Ro = new SelectList(_context.Roles, "RoleId", "RoleName");
            //important because we want it to show in the second time we refresh or enter invalid data
            return View(reg);
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(string UserEmail, string UserPassword)
        {
            if (ModelState.IsValid)
            {
                var userData = _context.Users.FirstOrDefault(x => x.UserEmail == UserEmail);
                if (userData != null && userData.UserPassword == UserPassword)
                {
                    return View(nameof(LogInSuccessful));
                }

                return View(nameof(NoAccess));
            }
            return View();
        }
        public IActionResult LogInSuccessful()
        {
            return View();
        }
        public IActionResult NoAccess()
        {
            return View();
        }
    }
}
