using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.ProductOperations.Commands.CreateProduct;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ProductOperations.Commands.CreateProduct
{
    public class CreateProductCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly OnlineStoreDbContext context;
        private readonly IMapper mapper;

        public CreateProductCommandTests(CommonTestFixture testFixture)
        {
            this.context = testFixture.Context;
            this.mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyProductTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // arrange (Hazırlık)
            var product = new Product()
            {
                Title="Tests"
            };
            context.Products.Add(product);
            context.SaveChanges();

            CreateProductCommand command = new(context, mapper);
            command.Model = new CreateProductModel { Title = product.Title };

            // act & assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Product already exists.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Product_ShouldBeCreated()
        {
            // arrange
            CreateProductCommand command = new(context, mapper);
            CreateProductModel model = new CreateProductModel()
            {
                Title="Tests"
            };

            command.Model = model;

            // act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            // assert
            var product = context.Products.SingleOrDefault(g => g.Title == model.Title);
            product.Should().NotBeNull();
            product.Title.Should().Be(model.Title);
            }
    }
}