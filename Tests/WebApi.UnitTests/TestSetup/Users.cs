using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Users
    {
        public static void AddUsers(this OnlineStoreDbContext context)
        {
            context.Users.AddRange( 
                    new User
                    {
                        Name ="Özlem",
                        Surname="Özçelik",
                        Email="ozlm@gmail.com",
                        Password="1234",
                        UserDate=new DateTime(2023,01,01),
                        Role="Admin"
                    }
                );
        }


    }
}