using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WishList.Models;


namespace WishList.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        
        private readonly UserManager<RegisterViewModel> _userManager;
        private readonly SignInManager<RegisterViewModel> _signInManager;

        public AccountController(UserManager<RegisterViewModel> user, SignInManager<RegisterViewModel> signIn)
        {
            _userManager = user;
            _signInManager = signIn;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            
            return View("Register");
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //var result = _userManager.CreateAsync(new ApplicationUser() { Email = model.Email, UserName = model.Email }, model.Password).Result;
            return RedirectToAction("HomeController.Index");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            return RedirectToAction("Index", "Item");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

