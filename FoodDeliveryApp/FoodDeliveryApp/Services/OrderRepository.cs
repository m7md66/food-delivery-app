using FoodDeliveryApp.DbContext;
using FoodDeliveryApp.IServices;
using FoodDeliveryApp.Models;
using FoodDeliveryApp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace FoodDeliveryApp.Services
{
    public class OrderRepository:IOrderRepository
    {

        private readonly FoodAppContext _foodAppContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderRepository(FoodAppContext foodAppContext ,UserManager<ApplicationUser> userManager)
        {
        _foodAppContext = foodAppContext;
            _userManager = userManager;
        }

        public IList<Order> GetOrders()
        {
            return _foodAppContext.Orders.ToList();
        }
        public int AddOrder(Order order) {
         
         _foodAppContext.Orders.Add(order);
           var result= _foodAppContext.SaveChanges();
            return result;
        }
        public int CheckUserOrders(string userId) {
         
        IList<Order> UserOrders= _foodAppContext.Orders.Where(a=>a.UserId== userId).ToList();
        
            return UserOrders.Count();
        }
        public IList<OrderList> GetOrderList()
        {
         
            IList<OrderList> orderLists= _foodAppContext.Orders.
                Select(a=>new OrderList{OrderRefrence=a.Number,OrderTime=a.OrderDate,TotalPrice=a.TotalPrice,DeliveredState=a.IsDelivered,CustomerClass=a.User.UserClass,CustomerName=a.User.Name}).ToList();
            foreach (var order in orderLists) 
            {
                var indexes = _foodAppContext.OrderItems. Where(o => o.OrdersId == order.OrderRefrence).Select(o=>o.ItemId).ToList();
                foreach (var index in indexes) {
                    order.items = _foodAppContext.Items.Where(a => a.Id == index).ToList();
                    foreach (var item in order.items) { order.TotalPrice += item.Price; }
                }

            }
           
            return orderLists;
        
        }

        public void IsDeliver(int orderId) { 
        var isDeliverd=_foodAppContext.Orders.Where(a=>a.Number==orderId).Select(a=>a.IsDelivered).SingleOrDefault();
            if (!isDeliverd) {
                var order = _foodAppContext.Orders.Where(a => a.Number == orderId).SingleOrDefault();
                order.IsDelivered = true;
            }
        }

    }
}
