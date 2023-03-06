using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.ProductShoppingListOperations.Queries.GetProductShoppingListDetail
{
    public class GetProductShoppingListDetailQuery
    {
        public int ProductShoppingListId { get; set; }
        public readonly IOnlineStoreDbContext _contex;
        public readonly IMapper _mapper;
        public GetProductShoppingListDetailQuery(IOnlineStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public ProductShoppingListDetailViewModel Handle()
        {
            var productShoppingList = _contex.Products.Include(i=> i.ProductShoppingLists).ThenInclude(t=> t.ShoppingList).SingleOrDefault(x=>x.Id == ProductShoppingListId);
            if(productShoppingList is null)
            {
                throw new InvalidOperationException("Product Shopping List not found.");
            }
            ProductShoppingListDetailViewModel vm= _mapper.Map<ProductShoppingListDetailViewModel>(productShoppingList);

            return vm;
        }
    }
    public class ProductShoppingListDetailViewModel
    {
        public int ProductId { get; set; }
        public int ShoppingListId { get; set; }
    }
}