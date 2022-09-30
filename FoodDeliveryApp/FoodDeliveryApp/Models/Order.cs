using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryApp.Models
{
    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        [Key]
        public int Number { get; set; }
     
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }
        public bool IsDelivered { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
