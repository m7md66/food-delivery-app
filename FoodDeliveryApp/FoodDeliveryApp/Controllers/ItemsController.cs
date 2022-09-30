using FoodDeliveryApp.IServices;
using FoodDeliveryApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsRepository itemsRepository;
        public ItemsController(IItemsRepository itemsRepository)
        { 
            this.itemsRepository = itemsRepository; 
        }
        public IActionResult Index()
        {
            var items =itemsRepository.getItems();
            return View(items);
        }
    }
}
