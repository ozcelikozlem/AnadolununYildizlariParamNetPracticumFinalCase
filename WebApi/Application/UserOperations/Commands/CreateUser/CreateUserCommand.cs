using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IOnlineStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateUserCommand(IOnlineStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user =_dbContext.Users.SingleOrDefault(x=> x.Email == Model.Email);
            if(user is not null)
            {
                throw new InvalidOperationException("User already exists.");
            }
            user = _mapper.Map<User>(Model);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
        public class CreateUserModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string UserDate { get; set; }
            public string Role { get; set; }
        }
    
}