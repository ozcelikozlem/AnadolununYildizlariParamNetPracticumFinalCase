using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.ProductOperations.Commands.DeleteProduct;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ProductOperations.Commands.DeleteProduct
{
    public class DeleteProductCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenProductIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int pId )
        {
            //arrange
           DeleteProductCommand command = new DeleteProductCommand(null);
           command.ProductId = pId;

            //act
            DeleteProductCommandValidator validator = new DeleteProductCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenProductIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           DeleteProductCommand command = new DeleteProductCommand(null);
           command.ProductId = 2;

            //act
            DeleteProductCommandValidator validator = new DeleteProductCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}