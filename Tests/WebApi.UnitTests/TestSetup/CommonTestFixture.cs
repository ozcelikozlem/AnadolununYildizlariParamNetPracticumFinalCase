using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public OnlineStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<OnlineStoreDbContext>().UseInMemoryDatabase(databaseName:"OnlineStoreTestDB").Options;
            Context = new OnlineStoreDbContext(options);

            Context.Database.EnsureCreated();
            Context.AddCategories();
            Context.AddMeasures();
            Context.AddProducts();
            Context.AddShoppingLists();
            Context.AddUsers();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg=> {cfg.AddProfile<MappingProfile>(); }).CreateMapper();

        }
    }
}