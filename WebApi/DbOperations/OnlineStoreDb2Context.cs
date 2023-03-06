using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class OnlineStoreDb2Context : DbContext, IOnlineStoreDb2Context
    {
        public OnlineStoreDb2Context(DbContextOptions<OnlineStoreDb2Context> options):base(options)
        {

        }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductShoppingList> ProductShoppingLists { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }

}