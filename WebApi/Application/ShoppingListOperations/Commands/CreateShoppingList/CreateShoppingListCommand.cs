using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ShoppingListOperations.Commands.CreateShoppingList
{
    public class CreateShoppingListCommand
    {
        public CreateShoppingListModel Model {get; set;}
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateShoppingListCommand(IOnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var shoppingList = _context.ShoppingLists.SingleOrDefault();

            shoppingList = _mapper.Map<ShoppingList>(Model);

            _context.ShoppingLists.Add(shoppingList);
            _context.SaveChanges();
        }
    }
    public class CreateShoppingListModel
    {
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }
        public DateTime ShoppingDate { get; set; }

    }
}