using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.ShoppingListOperations.Commands.DeleteShoppingList;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ShoppingListOperations.Commands.DeleteShoppingList
{
    public class DeleteShoppingListCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenShoppingListIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int shoppingListId )
        {
            //arrange
           DeleteShoppingListCommand command = new DeleteShoppingListCommand(null);
           command.ShoppingListId = shoppingListId;

            //act
            DeleteShoppingListCommandValidator validator = new DeleteShoppingListCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenDeleteShoppingListIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           DeleteShoppingListCommand command = new DeleteShoppingListCommand(null);
           command.ShoppingListId = 2;

            //act
            DeleteShoppingListCommandValidator validator = new DeleteShoppingListCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}