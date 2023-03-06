using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ProductOperations.Queries.GetProducts
{
    public class GetProductsQuery
    {
        public readonly IOnlineStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetProductsQuery(IOnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ProductsViewModel> Handle()
        {
            List<Product> products = _context.Products.Include(i => i.Category).Include(i => i.Measure).OrderBy(x=> x.Id).ToList();                    
            List<ProductsViewModel> vm = _mapper.Map<List<ProductsViewModel>>(products);
            return vm;
        }
    }

    public class ProductsViewModel
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string Measure { get; set; }
        public DateTime ProductDate { get; set; }
    }
}