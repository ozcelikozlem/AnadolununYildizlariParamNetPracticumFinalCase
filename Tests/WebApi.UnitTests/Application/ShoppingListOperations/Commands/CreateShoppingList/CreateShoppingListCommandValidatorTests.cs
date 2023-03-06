using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.ShoppingListOperations.Commands.CreateShoppingList;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ShoppingListOperations.Commands.CreateShoppingList
{
    public class CreateShoppingListCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,0,0)]
        [InlineData(1,0,0)]
        [InlineData(-5,-5,0)]
        [InlineData(-5,-5,1)]
        [InlineData(0,1,-5)]
        [InlineData(0,1,1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int quantity, int price,int userId)
        {
            //arrange
           CreateShoppingListCommand command = new CreateShoppingListCommand(null,null);
           command.Model =new CreateShoppingListModel()
           {
                Quantity=quantity,
                Price=price,
                UserId=userId

           };

            //act
            CreateShoppingListCommandValidator validator = new CreateShoppingListCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            CreateShoppingListCommand command = new CreateShoppingListCommand(null,null);
            command.Model =new CreateShoppingListModel()
            {
                Quantity=2,
                Price=100,
                UserId=1

            };

            //act
            CreateShoppingListCommandValidator validator = new CreateShoppingListCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}