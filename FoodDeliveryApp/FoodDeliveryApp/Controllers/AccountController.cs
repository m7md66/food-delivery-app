using FoodDeliveryApp.IServices;
using FoodDeliveryApp.Models;
using FoodDeliveryApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(IAccountRepository accountRepository, SignInManager<ApplicationUser> signInManager)
        {
            _accountRepository = accountRepository;
            _signInManager = signInManager; 
        }
        //ApplicationUser us = new ApplicationUser();
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegisterAccountViewModel newAccount)
        {
            if (!ModelState.IsValid)
            {
                return View(newAccount);

            }
            else
            {
               
                IdentityResult result = await _accountRepository.Registration(newAccount);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Orders");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);

                    }

                    return View(newAccount);
                }
            }

        }

        // log IN
        public IActionResult Login()
        {
         
          
            return View();
        }

        // assighn user to role 
        // await usermanager.AddToRoleAsync(user,"admin");

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel newLogin)
        {
            if (ModelState.IsValid == true)
            {
                Microsoft.AspNetCore.Identity.SignInResult signInResult = await _accountRepository.Login(newLogin);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("index", "Orders");
                }
                else
                {
                    ModelState.AddModelError("", "elpassword not matche");
                    return View(newLogin);
                }
            }
            else
            { 
            return View(newLogin);
            }
              
        }
        // log OUT
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }
    }
}
