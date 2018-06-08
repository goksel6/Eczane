using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Edura.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Edura.WebUI.IdentityCore;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Edura.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
    


        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;



        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returlUrl)
        {

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return Redirect(returlUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(model.Email), "Hatalı kullanıcı adı yada parola");
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            var userBulunan = await userManager.FindByEmailAsync(model.Email);

            if (ModelState.IsValid)
            {
                if (userBulunan == null)
                {

                    ApplicationUser user = new ApplicationUser();
                    user.Name = model.Name;
                    user.SurName = model.Surname;
                    user.Email = model.Email;
                    user.UserName = model.Username;
                    IdentityResult result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");

                    }

                    else
                    {
                        //HATA OLUŞTURDUK, ID VERDİK.
                        ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası.");


                    }
                }
                else
                {
                    ModelState.AddModelError("RegisterAlreadySaved", "Bu kullanıcı sistemde zaten kayıtlı.");
                }




            }


            return View(model);
        }



        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}