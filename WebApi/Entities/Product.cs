using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}
        public string Title { get; set; }
        public int Price { get; set;}
        public bool IActive { get; set; } =true;
        public DateTime ProductDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int MeasureId { get; set; }
        public Measure Measure { get; set; }
        public virtual ICollection<ProductShoppingList> ProductShoppingLists { get; set; }

        
    }
}