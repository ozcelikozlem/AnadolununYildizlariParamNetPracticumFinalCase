using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class ShoppingLists
    {
        public static void AddShoppingLists(this OnlineStoreDbContext context)
        {
            context.ShoppingLists.AddRange( 
                    new ShoppingList
                    {
                        Quantity=1,
                        Price=100,
                        ShoppingDate= new DateTime(2022,05,06)
                    },
                    new ShoppingList
                    {
                        Quantity=1,
                        Price=200,
                        ShoppingDate= new DateTime(2022,06,06)
                    },
                    new ShoppingList
                    {
                        Quantity=2,
                        Price=100,
                        ShoppingDate= new DateTime(2022,07,06)
                    }
                );
        }

    }
}