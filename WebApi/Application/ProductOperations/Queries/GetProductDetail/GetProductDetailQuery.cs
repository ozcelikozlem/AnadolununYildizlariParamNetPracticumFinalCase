using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ProductOperations.Queries.GetProductDetail
{
    public class GetProductDetailQuery
    {
        public int ProductId { get; set; }
        public readonly IOnlineStoreDbContext _contex;
        public readonly IMapper _mapper;
        public GetProductDetailQuery(IOnlineStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public ProductDetailViewModel Handle()
        {
            var product = _contex.Products.Include(x=> x.Category).Include(x=>x.Measure).Where(x => x.IActive && x.Id == ProductId ).SingleOrDefault();
            if(product is null)
            {
                throw new InvalidOperationException("Product not found.");
            }
            ProductDetailViewModel vm= _mapper.Map<ProductDetailViewModel>(product);

            return vm;
        }
    }
    public class ProductDetailViewModel
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string Measure { get; set; }
        public DateTime ProductDate { get; set; }
    }
}