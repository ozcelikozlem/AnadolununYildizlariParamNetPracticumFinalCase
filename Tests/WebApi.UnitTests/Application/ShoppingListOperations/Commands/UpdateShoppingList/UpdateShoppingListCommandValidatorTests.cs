using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using WebApi.Application.ShoppingListOperations.Commands.UpdateShoppingList;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ShoppingListOperations.Commands.UpdateShoppingList
{
    public class UpdateShoppingListCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,0,0,0)]
        [InlineData(0,1,1,0)]
        [InlineData(0,1,0,1)]
        [InlineData(0,0,1,1)]
        [InlineData(1,1,1,0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id,int quantity, int price,int userId )
        {
            //arrange
           UpdateShoppingListCommand command = new UpdateShoppingListCommand(null);
           command.Model =new UpdateShoppingListModel()
           {
                Quantity=quantity,
                Price=price,
                UserId=userId
           };
           command.ShoppingListId = id;

            //act
            UpdateShoppingListCommandValidator validator = new UpdateShoppingListCommandValidator();
            var result = validator.Validate(command);

            //assert
            
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            UpdateShoppingListCommand command = new UpdateShoppingListCommand(null);
            command.Model =new UpdateShoppingListModel()
            {
                Quantity=3,
                Price=200,
                UserId=1

            };
            command.ShoppingListId = 3;
            
            //act
            UpdateShoppingListCommandValidator validator = new UpdateShoppingListCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}