using FoodDeliveryApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.DbContext
{
    public class FoodAppContext : IdentityDbContext<ApplicationUser>
    {
        public FoodAppContext()
        {

        }
        public FoodAppContext(DbContextOptions<FoodAppContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //  optionsBuilder.UseSqlServer("server=.; database=TabadolDB; trusted_connection = true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderItems>()
              .HasKey(bc => new { bc.OrdersId, bc.ItemId });

            base.OnModelCreating(builder);



        }

        //private void OnModelCreatingPartial(ModelBuilder builder)
        //{
        //    throw new NotImplementedException();
        //}
    }
}