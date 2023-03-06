using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.ProductOperations.Commands.UpdateProduct
{
    public class UpdateProductCommand
    {
        public int ProductId { get; set; }
        public UpdateProductModel Model {get; set;}
        private readonly IOnlineStoreDbContext _context;
        public UpdateProductCommand(IOnlineStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var product = _context.Products.SingleOrDefault(x=> x.Id == ProductId);
            if(product is null)
            {
                throw new InvalidOperationException("Product not found.");
            }
            if(_context.Products.Any(x => x.Title.ToLower() == Model.ProductTitle.ToLower() && x.Id != ProductId))
            {
                throw new InvalidOperationException("This Product Already Exists.");
            }
            product.Title=string.IsNullOrEmpty(Model.ProductTitle.Trim()) ? product.Title : Model.ProductTitle;
            product.IActive =Model.IsActive;
            product.Price= Model.Price;
            product.ProductDate =DateTime.Now.Date;
            product.CategoryId=Model.CategoryId;
            product.MeasureId=Model.MeasureId;
            _context.SaveChanges();
        }
    }
     public class UpdateProductModel
     {
        public string ProductTitle { get; set; }
        public bool IsActive { get; set; } = true;
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int MeasureId { get; set; }
        public DateTime ProductDate { get; set; }

     }
}