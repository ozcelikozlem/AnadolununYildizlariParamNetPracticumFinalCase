using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.CategoryOperations.Commands.DeleteCategory
{
    public class DeleteCategoryCommand
    {
        public int CategoryId { get; set; }
        private readonly IOnlineStoreDbContext _context;
        public DeleteCategoryCommand(IOnlineStoreDbContext context)
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
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}