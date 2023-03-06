using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context =new OnlineStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<OnlineStoreDbContext>>()))
            {
                if(context.Products.Any())
                {
                    return;
                }

                context.Products.AddRange(
                    new Product
                    {
                        Title="Pants",
                        Price=100,
                        ProductDate= new DateTime(2022,03,06),
                        CategoryId=4,
                        MeasureId=4
                    },
                    new Product
                    {
                        Title="Cherry",
                        Price=60,
                        ProductDate= new DateTime(2022,06,03),
                        CategoryId=1,
                        MeasureId=1
                    },
                    new Product
                    {
                        Title="Fountain Pen",
                        Price=45,
                        ProductDate= new DateTime(2022,09,07),
                        CategoryId=3,
                        MeasureId=1
                    }
                    

                );

                context.Categories.AddRange(
                    new Category
                    {
                        Title="Food"
                    },
                    new Category
                    {
                        Title="Book"
                    },
                    new Category
                    {
                        Title="Stationery"
                    },
                   new Category
                    {
                        Title="Clothes"
                    }
                    
                );
                context.Measures.AddRange(
                    new Measure
                    {
                        Title="kg"
                    },
                    new Measure
                    {
                        Title="gr"
                    },
                    new Measure
                    {
                        Title="lt"
                    },
                   new Measure
                    {
                        Title="piece"
                    }
                    
                );

                context.ProductShoppingLists.AddRange(
                    new ProductShoppingList
                    {
                        ProductId=1,
                        ShoppingListId=1
                        
                    },
                    new ProductShoppingList
                    {
                        ProductId=2,
                        ShoppingListId=1
                        
                    },
                    new ProductShoppingList
                    {
                        ProductId=1,
                        ShoppingListId=2
                        
                    },
                    new ProductShoppingList
                    {
                        ProductId=2,
                        ShoppingListId=2
                        
                    },
                    new ProductShoppingList
                    {
                        ProductId=3,
                        ShoppingListId=2
                        
                    },
                     new ProductShoppingList
                    {
                        ProductId=2,
                        ShoppingListId=3
                        
                    }
                );

                context.Users.AddRange( 
                    new User
                    {
                        Name ="Özlem",
                        Surname="Özçelik",
                        Email="ozlm@gmail.com",
                        Password="1234",
                        UserDate=new DateTime(2021,01,01),
                        Role="Administrator"
                    },
                    new User
                    {
                        Name ="Özlema",
                        Surname="Özçelika",
                        Email="ozlm0@gmail.com",
                        Password="12345",
                        UserDate=new DateTime(2022,01,01),
                        Role="User"
                    }
                );
                context.ShoppingLists.AddRange( 
                    new ShoppingList
                    {
                        Quantity=1,
                        Price=100,
                        ShoppingDate= new DateTime(2022,05,06),
                        UserId=1

                    },
                    new ShoppingList
                    {
                        Quantity=1,
                        Price=200,
                        ShoppingDate= new DateTime(2022,06,06),
                        UserId=1
                    },
                    new ShoppingList
                    {
                        Quantity=2,
                        Price=100,
                        ShoppingDate= new DateTime(2022,07,06),
                        UserId=1
                    }
                );
                context.SaveChanges();

            }
        }
    }
}