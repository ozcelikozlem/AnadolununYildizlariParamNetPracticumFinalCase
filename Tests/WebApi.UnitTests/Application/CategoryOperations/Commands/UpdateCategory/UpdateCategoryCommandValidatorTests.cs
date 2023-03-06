using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.CategoryOperations.Commands.UpdateCategory;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.CategoryOperations.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,"Lor")]
        [InlineData(0," ")]
        [InlineData(1," ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int cId,string title )
        {
            //arrange
           UpdateCategoryCommand command = new UpdateCategoryCommand(null);
           command.Model =new UpdateCategoryModel()
           {
                CategoryTitle = title
           };
           command.CategoryId = cId;

            //act
            UpdateCategoryCommandValidator validator = new UpdateCategoryCommandValidator();
            var result = validator.Validate(command);

            //assert
            
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            UpdateCategoryCommand command = new UpdateCategoryCommand(null);
            command.Model =new UpdateCategoryModel()
            {
                CategoryTitle = "Lord of The Rings",

            };
            command.CategoryId = 3;
            
            //act
            UpdateCategoryCommandValidator validator = new UpdateCategoryCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}