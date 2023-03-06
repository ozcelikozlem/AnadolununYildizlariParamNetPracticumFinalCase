using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ShoppingListOperations.Queries.GetShoppingLists
{
    public class GetShoppingListsQuery
    {
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetShoppingListsQuery(IOnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ShoppingListQueryViewModel> Handle()
        {
            var shoppingList = _context.ShoppingLists.Include(x=> x.User).Include(x=>x.ProductShoppingLists).ThenInclude(i=>i.Product).OrderBy(x=>x.Id).ToList<ShoppingList>();
            List<ShoppingListQueryViewModel> vm = _mapper.Map<List<ShoppingListQueryViewModel>>(shoppingList);
            return vm;
        }
    }

    public class ShoppingListQueryViewModel
    {
         public int Quantity { get; set; }
        public int Price { get; set; }
        public string User { get; set; }
        public IReadOnlyCollection<string> ProductShoppingLists { get; set; }
        public DateTime ShoppingDate { get; set; }
    }
}