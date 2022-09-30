using FoodDeliveryApp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace FoodDeliveryApp.IServices
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> Registration(RegisterAccountViewModel newAccount);
        public Task<Microsoft.AspNetCore.Identity.SignInResult> Login(LoginViewModel newLogin);
        public int UpgradeUserVIP(string userId);
    }
}
