using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.ViewModels
{
    public class OrderList
    {
        public int OrderRefrence { get; set; }
        public DateTime OrderTime { get; set; }
        public int TotalPrice { get; set; }
        public bool DeliveredState { get; set; }
        public string CustomerName { get; set; }
        public string CustomerClass { get; set; }
        public IList<Items> items { get; set; }
    }
}
