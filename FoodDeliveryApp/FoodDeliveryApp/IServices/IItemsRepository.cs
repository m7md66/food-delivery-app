using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.IServices
{
    public interface IItemsRepository
    {
        public IList<Items> getItems();
    }
}
