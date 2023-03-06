using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Products
    {
        public static void AddProducts(this OnlineStoreDbContext context)
        {
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
        }
    }
}