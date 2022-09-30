namespace FoodDeliveryApp.Models
{
    public class Items
    {
        public Items()
        {
            OrderItems = new HashSet<OrderItems>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
