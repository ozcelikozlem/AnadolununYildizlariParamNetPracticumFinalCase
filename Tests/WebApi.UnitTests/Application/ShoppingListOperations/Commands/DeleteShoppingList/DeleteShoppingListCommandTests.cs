using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.ShoppingListOperations.Commands.DeleteShoppingList;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ShoppingListOperations.Commands.DeleteShoppingList
{
    public class DeleteShoppingListCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly OnlineStoreDbContext _context;
        public DeleteShoppingListCommandTests(CommonTestFixture testFixture)
        {
          _context = testFixture.Context;
        }

         [Fact]
        public void WhenGivenShoppingListIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            DeleteShoppingListCommand command =new DeleteShoppingListCommand(_context);
            command.ShoppingListId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Shopping List not found.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_ShoppingList_ShouldBeDeleted()
        {
            //arrange
            DeleteShoppingListCommand command =new DeleteShoppingListCommand(_context);
            command.ShoppingListId=1;

            //act
            DeleteShoppingListCommandValidator validator = new DeleteShoppingListCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}