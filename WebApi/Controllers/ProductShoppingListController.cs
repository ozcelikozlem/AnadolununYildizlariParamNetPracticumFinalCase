using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ProductShoppingListOperations.Commands.CreateProductShoppingList;
using WebApi.Application.ProductShoppingListOperations.Commands.DeleteProductShoppingList;
using WebApi.Application.ProductShoppingListOperations.Commands.UpdateProductShoppingList;
using WebApi.Application.ProductShoppingListOperations.Queries.GetProductShoppingListDetail;
using WebApi.Application.ProductShoppingListOperations.Queries.GetProductShoppingLists;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class ProductShoppingListController : ControllerBase
    {
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;

        public ProductShoppingListController(IOnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetProductShoppingLists()
        {
            GetProductShoppingListsQuery query = new GetProductShoppingListsQuery(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("id")]
        public ActionResult GetProductShoppingListDetail(int id)
        {
            GetProductShoppingListDetailQuery query = new GetProductShoppingListDetailQuery(_context,_mapper);
            query.ProductShoppingListId =id;
            GetProductShoppingListDetailQueryValidator validator = new GetProductShoppingListDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddProductShoppingList([FromBody] CreateProductShoppingListModel newCreateProductShoppingList)
        {
            CreateProductShoppingListCommand command = new CreateProductShoppingListCommand(_context,_mapper);
            command.Model=newCreateProductShoppingList;

            CreateProductShoppingListCommandValidator validator = new CreateProductShoppingListCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateProductShoppingList(int id, [FromBody] UpdateProductShoppingListModel updateProductShoppingList)
        {
            UpdateProductShoppingListCommand command = new UpdateProductShoppingListCommand(_context);
            command.ProductShoppingListId=id;
            command.Model = updateProductShoppingList;

            UpdateProductShoppingListCommandValidator validator = new UpdateProductShoppingListCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteProductShoppingList(int id)
        {
            DeleteProductShoppingListCommand command = new DeleteProductShoppingListCommand(_context);
            command.ProductShoppingListId=id;

            DeleteProductShoppingListCommandValidator validator = new DeleteProductShoppingListCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}