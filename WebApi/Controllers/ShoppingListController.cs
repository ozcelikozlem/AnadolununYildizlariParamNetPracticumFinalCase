using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ShoppingListOperations.Commands.CreateShoppingList;
using WebApi.Application.ShoppingListOperations.Commands.DeleteShoppingList;
using WebApi.Application.ShoppingListOperations.Commands.UpdateShoppingList;
using WebApi.Application.ShoppingListOperations.Queries.GetShoppingListDetail;
using WebApi.Application.ShoppingListOperations.Queries.GetShoppingLists;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]s")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;

        public ShoppingListController(IOnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetShoppingLists()
        {
            GetShoppingListsQuery query = new GetShoppingListsQuery(_context,_mapper);
            var response = query.Handle();

            return Ok(response);
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetMovieDetail(int id)
        {
            GetShoppingListDetailQuery query = new GetShoppingListDetailQuery(_context,_mapper);
            query.ShoppingListId = id;

            GetShoppingListDetailQueryValidator validator = new GetShoppingListDetailQueryValidator();
            validator.ValidateAndThrow(query);
            
            var result = query.Handle();

            return Ok(result);
        }

        [Authorize(Roles ="User")]
        [HttpPost]
        public IActionResult CrateMovie([FromBody] CreateShoppingListModel model)
        {
            CreateShoppingListCommand command = new CreateShoppingListCommand(_context,_mapper);
            command.Model = model;

            CreateShoppingListCommandValidator validator = new CreateShoppingListCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            
            return Ok();
        }

        [Authorize(Roles ="User")]
        [HttpPut("{id}")]
        public IActionResult UpdateMovie([FromBody] UpdateShoppingListModel model, int id)
        {
            UpdateShoppingListCommand command = new UpdateShoppingListCommand(_context);
            command.Model = model;
            command.ShoppingListId = id;

            UpdateShoppingListCommandValidator validator = new UpdateShoppingListCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [Authorize(Roles ="User")]
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteShoppingListCommand command = new DeleteShoppingListCommand(_context);
            command.ShoppingListId = id;

            DeleteShoppingListCommandValidator validator = new DeleteShoppingListCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

    }
}