using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ProductShoppingListOperations.Commands.CreateProductShoppingList
{
    public class CreateProductShoppingListCommand
    {
        public CreateProductShoppingListModel Model {get; set;}
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateProductShoppingListCommand(IOnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var productShopping = _context.ProductShoppingLists.SingleOrDefault(x=> x.ProductId == Model.ProductId && x.ShoppingListId == Model.ShoppingListId );
            if(productShopping is not null)
            {
                throw new InvalidOperationException("Product ShoppingList already exists.");
            }

            productShopping = _mapper.Map<ProductShoppingList>(Model);

            _context.ProductShoppingLists.Add(productShopping);
            _context.SaveChanges();
        }
    }
    
    public class CreateProductShoppingListModel
    {
        public int ProductId { get; set; }
        public int ShoppingListId { get; set; }
    }
   
}