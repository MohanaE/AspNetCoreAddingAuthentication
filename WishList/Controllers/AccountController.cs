using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WishList.Models;
using Microsoft.AspNetCore.Identity;
/*using WishList.Models.AccountViewModels;*/

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
    }
}
