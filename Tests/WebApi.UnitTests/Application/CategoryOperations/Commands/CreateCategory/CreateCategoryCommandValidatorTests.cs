using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.CategoryOperations.Commands.CreateCategory;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lor")]
        [InlineData(" ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title)
        {
            //arrange
           CreateCategoryCommand command = new CreateCategoryCommand(null,null);
           command.Model =new CreateCategoryModel()
           {
                Title=title
           };

            //act
            CreateCategoryCommandValidator validator = new CreateCategoryCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            CreateCategoryCommand command = new CreateCategoryCommand(null,null);
            command.Model =new CreateCategoryModel()
            {
                Title="title"
            };

            //act
            CreateCategoryCommandValidator validator = new CreateCategoryCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}