using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class OnlineStoreDbContext : DbContext, IOnlineStoreDbContext
    {
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductShoppingList> ProductShoppingLists { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<User> Users { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}