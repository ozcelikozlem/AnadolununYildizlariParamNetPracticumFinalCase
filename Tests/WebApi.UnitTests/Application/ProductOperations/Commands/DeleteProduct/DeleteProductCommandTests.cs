using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.ProductOperations.Commands.DeleteProduct;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ProductOperations.Commands.DeleteProduct
{
    public class DeleteProductCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly OnlineStoreDbContext _context;
        public DeleteProductCommandTests(CommonTestFixture testFixture)
        {
          _context = testFixture.Context;
        }

         [Fact]
        public void WhenGivenProductIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            DeleteProductCommand command =new DeleteProductCommand(_context);
            command.ProductId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Product not found.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Product_ShouldBeDeleted()
        {
            //arrange
            DeleteProductCommand command =new DeleteProductCommand(_context);
            command.ProductId=1;

            //act
             DeleteProductCommandValidator validator = new DeleteProductCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}