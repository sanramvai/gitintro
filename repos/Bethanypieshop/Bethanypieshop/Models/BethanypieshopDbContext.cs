using Microsoft.EntityFrameworkCore;

namespace Bethanypieshop.Models
{
    public class BethanypieshopDbContext : DbContext
    {
        public BethanypieshopDbContext(DbContextOptions<BethanypieshopDbContext> options) : base(options)
        {

        }
        public DbSet<Catigory> Catigories { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems{ get; set;}
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
    
}
