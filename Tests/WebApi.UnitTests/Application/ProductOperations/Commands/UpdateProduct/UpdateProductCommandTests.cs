using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.ProductOperations.Commands.UpdateProduct;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ProductOperations.Commands.UpdateProduct
{
    public class UpdateProductCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly OnlineStoreDbContext _context;
        public UpdateProductCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenProductIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            UpdateProductCommand command =new UpdateProductCommand(_context);
            command.ProductId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Product not found.");

        }
        [Fact]
        public void WhenValidInputsAreGiven_Product_ShouldBeUpdated()
        {
            //arrange
            UpdateProductCommand command =new UpdateProductCommand(_context);
            UpdateProductModel model = new UpdateProductModel(){ProductTitle ="Tests"};
            command.Model = model;
            command.ProductId=3;
            //act
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            //assert
            var product=_context.Products.SingleOrDefault(a=> a.Id == command.ProductId);
            product.Should().NotBeNull();
            product.Title.Should().Be(model.ProductTitle);

    }
    }
}