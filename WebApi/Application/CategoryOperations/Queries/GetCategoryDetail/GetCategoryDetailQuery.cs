using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.CategoryOperations.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQuery
    {
        public int CategoryId { get; set; }
        public readonly IOnlineStoreDbContext _contex;
        public readonly IMapper _mapper;
        public GetCategoryDetailQuery(IOnlineStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public CategoryDetailViewModel Handle()
        {
            var category = _contex.Categories.Where(x => x.IActive && x.Id == CategoryId ).SingleOrDefault();
            if(category is null)
            {
                throw new InvalidOperationException("Category not found.");
            }
            CategoryDetailViewModel vm= _mapper.Map<CategoryDetailViewModel>(category);

            return vm;
        }
    }
    public class CategoryDetailViewModel
    {
        public string Title { get; set; }
        
    }
}