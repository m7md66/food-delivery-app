using FoodDeliveryApp.DbContext;
using FoodDeliveryApp.IServices;
using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.Services
{
    public class ItemsRepository:IItemsRepository
    {
        private readonly FoodAppContext _appContext;

        public ItemsRepository(FoodAppContext appContext)
        {
           _appContext = appContext;
        }
        public IList<Items> getItems()
        { 
            return _appContext.Items.ToList();
        }

    }
}
