using Microsoft.AspNetCore.Identity;

namespace FoodDeliveryApp.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            orders = new HashSet<Order>();
        }
        public string Name { get; set; }
        public string UserClass { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}
