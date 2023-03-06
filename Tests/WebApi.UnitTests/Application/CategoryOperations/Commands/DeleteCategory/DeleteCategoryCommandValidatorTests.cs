using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.CategoryOperations.Commands.DeleteCategory;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.CategoryOperations.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenCategoryIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int categoryId )
        {
            //arrange
           DeleteCategoryCommand command = new DeleteCategoryCommand(null);
           command.CategoryId = categoryId;

            //act
            DeleteCategoryCommandValidator validator = new DeleteCategoryCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenCategoryIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           DeleteCategoryCommand command = new DeleteCategoryCommand(null);
           command.CategoryId = 2;

            //act
            DeleteCategoryCommandValidator validator = new DeleteCategoryCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}