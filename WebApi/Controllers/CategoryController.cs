using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CategoryOperations.Commands.CreateCategory;
using WebApi.Application.CategoryOperations.Commands.DeleteCategory;
using WebApi.Application.CategoryOperations.Commands.UpdateCategory;
using WebApi.Application.CategoryOperations.Queries.GetCategories;
using WebApi.Application.CategoryOperations.Queries.GetCategoryDetail;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Authorize(Roles ="Administrator")]
    [ApiController]
    [Route("[controller]s")]
    public class CategoryController : ControllerBase
    {
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;

        public CategoryController(IOnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetCategory()
        {
            GetCategoriesQuery query = new GetCategoriesQuery(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("id")]
        public ActionResult GetCategoryDetail(int id)
        {
            GetCategoryDetailQuery query = new GetCategoryDetailQuery(_context,_mapper);
            query.CategoryId =id;
            GetCategoryDetailQueryValidator validator = new GetCategoryDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CreateCategoryModel newCategory)
        {
            CreateCategoryCommand command = new CreateCategoryCommand(_context,_mapper);
            command.Model=newCategory;

            CreateCategoryCommandValidator validator = new CreateCategoryCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoryModel updateCategory)
        {
            UpdateCategoryCommand command = new UpdateCategoryCommand(_context);
            command.CategoryId=id;
            command.Model = updateCategory;

            UpdateCategoryCommandValidator validator = new UpdateCategoryCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteCategory(int id)
        {
            DeleteCategoryCommand command = new DeleteCategoryCommand(_context);
            command.CategoryId=id;

            DeleteCategoryCommandValidator validator = new DeleteCategoryCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        
    }
}