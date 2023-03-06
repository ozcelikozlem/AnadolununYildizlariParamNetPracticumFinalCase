using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.ProductOperations.Commands.CreateProduct;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ProductOperations.Commands.CreateProduct
{
    public class CreateProductCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,0,0,"Lor")]
        [InlineData(0,0,0," ")]
        [InlineData(-5,-5,0,"Lor")]
        [InlineData(0,0,-5,"Tests")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int cId, int mId,int price,string title)
        {
            //arrange
           CreateProductCommand command = new CreateProductCommand(null,null);
           command.Model =new CreateProductModel()
           {
                Title=title,
                CategoryId=cId,
                MeasureId=mId,
                Price=price

           };

            //act
            CreateProductCommandValidator validator = new CreateProductCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            CreateProductCommand command = new CreateProductCommand(null,null);
            command.Model =new CreateProductModel()
            {
                Title="title",
                CategoryId=1,
                MeasureId=1,
                Price=100

            };

            //act
            CreateProductCommandValidator validator = new CreateProductCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}