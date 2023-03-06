using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime UserDate { get; set; }
        public string Role { get; set; }
        public bool IActive { get; set;} =true;
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }


    }
}