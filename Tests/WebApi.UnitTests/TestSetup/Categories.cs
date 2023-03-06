using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Categories
    {
        public static void AddCategories(this OnlineStoreDbContext context)
        {
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
        }
    }
}