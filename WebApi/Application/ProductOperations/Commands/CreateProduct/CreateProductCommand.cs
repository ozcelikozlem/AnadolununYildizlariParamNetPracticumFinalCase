using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ProductOperations.Commands.CreateProduct
{
    public class CreateProductCommand 
    {
        public CreateProductModel Model {get; set;}
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateProductCommand(IOnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var product = _context.Products.SingleOrDefault(x=> x.Title == Model.Title);
            if(product is not null)
            {
                throw new InvalidOperationException("Product already exists.");
            }

            product = _mapper.Map<Product>(Model);

            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
    public class CreateProductModel
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public DateTime ProductDate { get; set; }
        public int CategoryId { get; set; }
        public int MeasureId { get; set; }
    }
    
}