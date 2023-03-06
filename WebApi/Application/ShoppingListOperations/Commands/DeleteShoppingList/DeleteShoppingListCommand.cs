using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.ShoppingListOperations.Commands.DeleteShoppingList
{
    public class DeleteShoppingListCommand
    {
        public int ShoppingListId { get; set; }
        private readonly IOnlineStoreDbContext _context;
        public DeleteShoppingListCommand(IOnlineStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var shoppingList = _context.ShoppingLists.SingleOrDefault(x=> x.Id == ShoppingListId);
            if(shoppingList is null)
            {
                throw new InvalidOperationException("Shopping List not found.");
            }
            _context.ShoppingLists.Remove(shoppingList);
            _context.SaveChanges();
        }
    }
}