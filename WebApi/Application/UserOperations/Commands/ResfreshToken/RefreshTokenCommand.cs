using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebApi.DbOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Commands.ResfreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IOnlineStoreDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public RefreshTokenCommand(IOnlineStoreDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Users.FirstOrDefault(x=> x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if(user is not null)
            {
                //Token Yarat
                TokenHandler handler = new TokenHandler(_configuration);
                Token token =  handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();

                return token;
            }
            else
            throw new InvalidOperationException("No Valid Refresh Token Found!");
        }
    }
}