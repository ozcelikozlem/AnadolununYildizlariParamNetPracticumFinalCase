using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.ProductShoppingListOperations.Commands.DeleteProductShoppingList
{
    public class DeleteProductShoppingListCommand
    {
        public int ProductShoppingListId { get; set; }
        private readonly IOnlineStoreDbContext _context;
        public DeleteProductShoppingListCommand(IOnlineStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var productShoppingList = _context.ProductShoppingLists.SingleOrDefault(x=> x.Id== ProductShoppingListId);
            if(productShoppingList is null)
            {
                throw new InvalidOperationException("Product ShoppingList not found.");
            }
            _context.ProductShoppingLists.Remove(productShoppingList);
            _context.SaveChanges();
        }
    }
}