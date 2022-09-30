using FoodDeliveryApp.DbContext;
using FoodDeliveryApp.IServices;
using FoodDeliveryApp.Models;
using FoodDeliveryApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Services
{
    public class AccountRepository:IAccountRepository
    {
        private readonly FoodAppContext _foodAppContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
    
        public AccountRepository(FoodAppContext foodAppContext,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
           _foodAppContext = foodAppContext;
            _userManager = userManager;
            _signInManager = signInManager;
        
        }

        ApplicationUser user = new ApplicationUser();
       
        public async Task<IdentityResult> Registration(RegisterAccountViewModel newAccount)
        {
           if (newAccount != null) 
            user.UserName = newAccount.UserName;
            user.Email = newAccount.Email;
            user.Name = newAccount.Name;
            user.UserClass = "normal";


            IdentityResult result = await _userManager.CreateAsync(user, newAccount.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return result;
            }
            else
                return result;
        }

        // log IN
     
        // assighn user to role 
        // await usermanager.AddToRoleAsync(user,"admin");

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(LoginViewModel newLogin)
        {
                ApplicationUser user = await _userManager.FindByNameAsync(newLogin.UserName);
               
                    Microsoft.AspNetCore.Identity.SignInResult signInResult =
                        await _signInManager.PasswordSignInAsync(user, newLogin.Password, newLogin.IsPresist, false);
                    return signInResult;

        }

        public int UpgradeUserVIP(string userId) {
           ApplicationUser appUser= _foodAppContext.Users.FirstOrDefault(a => a.Id == userId);
            appUser.UserClass = "VIP";
            int result = _foodAppContext.SaveChanges();
            return result;
        }
    }
}
