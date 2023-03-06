using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ShoppingListOperations.Queries.GetShoppingListDetail
{
    public class GetShoppingListDetailQuery
    {
       public int ShoppingListId { get; set; }
        public readonly IOnlineStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetShoppingListDetailQuery(IOnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ShoppingListDetailViewModel Handle()
        {
            var shoppingList = _context.ShoppingLists.Include(i=> i.ProductShoppingLists).SingleOrDefault(x => x.Id == ShoppingListId);
            if(shoppingList is null)
            {
                throw new InvalidOperationException("Shopping List not found.");
            }

            ShoppingListDetailViewModel vm = _mapper.Map<ShoppingListDetailViewModel>(shoppingList);

            return vm;
        }
    }
    public class ShoppingListDetailViewModel
    {
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string User { get; set; }
        public IReadOnlyCollection<string> ProductShoppingLists { get; set; }
        public DateTime ShoppingDate { get; set; }
    }
}