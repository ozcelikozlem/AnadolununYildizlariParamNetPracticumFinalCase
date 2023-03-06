using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.ProductOperations.Commands.UpdateProduct;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ProductOperations.Commands.UpdateProduct
{
    public class UpdateProductCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,0,0,0,"Lor")]
        [InlineData(0,0,0,0," ")]
        [InlineData(0,1,0,1,"Lor")]
        [InlineData(0,0,1,1,"Lord")]
        [InlineData(1,1,1,0," ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id,int cId, int mId,int price,string title )
        {
            //arrange
           UpdateProductCommand command = new UpdateProductCommand(null);
           command.Model =new UpdateProductModel()
           {
                ProductTitle = title,
                CategoryId=cId,
                MeasureId=mId,
                Price=price
           };
           command.ProductId = id;

            //act
            UpdateProductCommandValidator validator = new UpdateProductCommandValidator();
            var result = validator.Validate(command);

            //assert
            
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            UpdateProductCommand command = new UpdateProductCommand(null);
            command.Model =new UpdateProductModel()
            {
                ProductTitle = "Pantssss",

            };
            command.ProductId = 1;
            
            //act
            UpdateProductCommandValidator validator = new UpdateProductCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}