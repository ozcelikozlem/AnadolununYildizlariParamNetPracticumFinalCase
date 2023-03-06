using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class ShoppingList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime ShoppingDate { get; set; }
        public bool IActive { get; set; } =true;
        public int UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<ProductShoppingList> ProductShoppingLists { get; set; }

    }
}