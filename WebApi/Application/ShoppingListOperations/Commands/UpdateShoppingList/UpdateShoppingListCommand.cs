using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.ShoppingListOperations.Commands.UpdateShoppingList
{
    public class UpdateShoppingListCommand
    {
        public int ShoppingListId { get; set; }
        public UpdateShoppingListModel Model {get; set;}
        private readonly IOnlineStoreDbContext _context;
        public UpdateShoppingListCommand(IOnlineStoreDbContext context)
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
            if(_context.ShoppingLists.Any(x =>  x.Id != ShoppingListId))
            {
                throw new InvalidOperationException("This Shopping List Already Exists.");
            }
            shoppingList.IActive =Model.IActive;
            shoppingList.Price= Model.Price;
            shoppingList.ShoppingDate =DateTime.Now.Date;
            shoppingList.Quantity=Model.Quantity;
            shoppingList.UserId=Model.UserId;
            _context.SaveChanges();
        }
    }
     public class UpdateShoppingListModel
     {
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }
        public DateTime ShoppingDate { get; set; }
        public bool IActive { get; set; } =true;
     }
}