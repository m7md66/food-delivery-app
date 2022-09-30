using FoodDeliveryApp.IServices;
using FoodDeliveryApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(IOrderRepository orderRepository , UserManager<ApplicationUser> userManager, IAccountRepository accountRepository)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
            _accountRepository = accountRepository;
        }
        //public IActionResult Index()
        //{
        //    var orders= _orderRepository.GetOrders();
        //    return View(orders);
        //}

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
           _orderRepository.AddOrder(order);
            string userId = _userManager.GetUserId(User);
            if (_orderRepository.CheckUserOrders(userId) > 3)
            {
                _accountRepository.UpgradeUserVIP(userId);
            }
            return View("index");
        }

       
        public IActionResult index()
        { 
       
            return View(_orderRepository.GetOrderList());
        }

        
        public IActionResult Deliver(int ID)
          {

            _orderRepository.IsDeliver(ID); 
            return RedirectToAction ("index");
        }
    }
}
