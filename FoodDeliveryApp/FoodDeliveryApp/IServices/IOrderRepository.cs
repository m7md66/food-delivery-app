using FoodDeliveryApp.Models;
using FoodDeliveryApp.ViewModels;

namespace FoodDeliveryApp.IServices
{
    public interface IOrderRepository
    {
        public IList<Order> GetOrders();
        public int AddOrder(Order order);
        public int CheckUserOrders(string userId);
        public IList<OrderList> GetOrderList();
        public void IsDeliver(int orderId);
    }
}
