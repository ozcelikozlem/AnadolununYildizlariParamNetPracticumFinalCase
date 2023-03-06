using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.ProductOperations.Commands.DeleteProduct
{
    public class DeleteProductCommand
    {
        public int ProductId { get; set; }
        private readonly IOnlineStoreDbContext _context;
        public DeleteProductCommand(IOnlineStoreDbContext context)
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
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}