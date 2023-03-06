using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.CategoryOperations.Commands.UpdateCategory
{
    public class UpdateCategoryCommand
    {
        public int CategoryId { get; set; }
        public UpdateCategoryModel Model {get; set;}
        private readonly IOnlineStoreDbContext _context;
        public UpdateCategoryCommand(IOnlineStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var category = _context.Categories.SingleOrDefault(x=> x.Id == CategoryId);
            if(category is null)
            {
                throw new InvalidOperationException("Category not found.");
            }
            if(_context.Categories.Any(x => x.Title.ToLower() == Model.CategoryTitle.ToLower() && x.Id != CategoryId))
            {
                throw new InvalidOperationException("This Category Already Exists.");
            }
            category.Title=string.IsNullOrEmpty(Model.CategoryTitle.Trim()) ? category.Title : Model.CategoryTitle;
            category.IActive =Model.IsActive;
            _context.SaveChanges();
        }
    }
     public class UpdateCategoryModel
     {
        public string CategoryTitle { get; set; }
        public bool IsActive { get; set; } = true;

     }
}