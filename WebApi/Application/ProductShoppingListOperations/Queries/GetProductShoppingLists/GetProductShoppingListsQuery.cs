using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.ProductShoppingListOperations.Queries.GetProductShoppingLists
{
    public class GetProductShoppingListsQuery
    {
        public readonly IOnlineStoreDbContext _contex;
        public readonly IMapper _mapper;
        public GetProductShoppingListsQuery(IOnlineStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public List<ProductShoppingListsViewModel> Handle()
        {
            var productShoppingList = _contex.ProductShoppingLists.OrderBy(x => x.Id);
            List<ProductShoppingListsViewModel> returnObj = _mapper.Map<List<ProductShoppingListsViewModel>>(productShoppingList);
            return returnObj;
        }
    }

    public class ProductShoppingListsViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ShoppingListId { get; set; }
    }
}