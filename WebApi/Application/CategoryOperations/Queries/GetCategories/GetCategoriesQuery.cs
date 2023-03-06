using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.CategoryOperations.Queries.GetCategories
{
    public class GetCategoriesQuery
    {
        public readonly IOnlineStoreDbContext _contex;
        public readonly IMapper _mapper;
        public GetCategoriesQuery(IOnlineStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public List<CategoriesViewModel> Handle()
        {
            var categories = _contex.Categories.Where(x => x.IActive).OrderBy(x => x.Id);
            List<CategoriesViewModel> returnObj = _mapper.Map<List<CategoriesViewModel>>(categories);
            return returnObj;
        }
    }

    public class CategoriesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    
}