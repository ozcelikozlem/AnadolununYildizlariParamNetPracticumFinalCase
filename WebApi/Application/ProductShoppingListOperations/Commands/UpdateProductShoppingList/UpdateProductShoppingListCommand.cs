using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.ProductShoppingListOperations.Commands.UpdateProductShoppingList
{
    public class UpdateProductShoppingListCommand
    {
        public int ProductShoppingListId { get; set; }
        public UpdateProductShoppingListModel Model {get; set;}
        private readonly IOnlineStoreDbContext _context;
        public UpdateProductShoppingListCommand(IOnlineStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var productShoppingList = _context.ProductShoppingLists.SingleOrDefault(x=> x.Id == ProductShoppingListId);
            if(productShoppingList is null)
            {
                throw new InvalidOperationException("Product ShoppingList not found.");
            }
            if(_context.ProductShoppingLists.Any(x => x.ProductId != Model.ProductId && x.ShoppingListId != Model.ShoppingListId))
            {
                throw new InvalidOperationException("This ProductShoppingLists Already Exists.");
            }
            productShoppingList.ProductId=Model.ProductId;
            productShoppingList.ShoppingListId = Model.ShoppingListId;
            _context.SaveChanges();
        }
    }
     public class UpdateProductShoppingListModel
     {
        public int ProductId { get; set; }
        public int ShoppingListId { get; set; } 

     }
}