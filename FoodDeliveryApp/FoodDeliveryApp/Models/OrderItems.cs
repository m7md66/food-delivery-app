using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryApp.Models
{
    public class OrderItems
    {
        public int ItemId { get; set; }
      
        public int OrdersId { get; set; }

       
        
        [ForeignKey(nameof(OrdersId))]
        public Order order { get; set; }

        [ForeignKey(nameof(ItemId))]
        public Items items { get; set; }
    }
}
