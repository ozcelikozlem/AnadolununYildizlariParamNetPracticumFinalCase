using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ProductOperations.Commands.CreateProduct;
using WebApi.Application.ProductOperations.Commands.DeleteProduct;
using WebApi.Application.ProductOperations.Commands.UpdateProduct;
using WebApi.Application.ProductOperations.Queries.GetProductDetail;
using WebApi.Application.ProductOperations.Queries.GetProducts;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ProductController : ControllerBase
    {
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(IOnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public ActionResult GetProducts()
        {
            GetProductsQuery query = new GetProductsQuery(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [Authorize]
        [HttpGet("id")]
        public ActionResult GetProductDetail(int id)
        {
            GetProductDetailQuery query = new GetProductDetailQuery(_context,_mapper);
            query.ProductId =id;
            GetProductDetailQueryValidator validator = new GetProductDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);
        }

        [Authorize(Roles ="Administrator")]
        [HttpPost]
        public IActionResult AddProduct([FromBody] CreateProductModel newCategory)
        {
            CreateProductCommand command = new CreateProductCommand(_context,_mapper);
            command.Model=newCategory;

            CreateProductCommandValidator validator = new CreateProductCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [Authorize(Roles ="Administrator")]       
        [HttpPut("id")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductModel updateProduct)
        {
            UpdateProductCommand command = new UpdateProductCommand(_context);
            command.ProductId=id;
            command.Model = updateProduct;

            UpdateProductCommandValidator validator = new UpdateProductCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [Authorize(Roles ="Administrator")]
        [HttpDelete("id")]
        public IActionResult DeleteCategory(int id)
        {
            DeleteProductCommand command = new DeleteProductCommand(_context);
            command.ProductId=id;

            DeleteProductCommandValidator validator = new DeleteProductCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}