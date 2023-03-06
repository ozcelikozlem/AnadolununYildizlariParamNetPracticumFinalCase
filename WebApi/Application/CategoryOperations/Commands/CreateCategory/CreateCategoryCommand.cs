using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryCommand
    {
        public CreateCategoryModel Model {get; set;}
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCategoryCommand(IOnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var category = _context.Categories.SingleOrDefault(x=> x.Title == Model.Title);
            if(category is not null)
            {
                throw new InvalidOperationException("Category already exists.");
            }

            category = _mapper.Map<Category>(Model);

            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
    public class CreateCategoryModel
    {
        public string Title { get; set; }
    }
    
}