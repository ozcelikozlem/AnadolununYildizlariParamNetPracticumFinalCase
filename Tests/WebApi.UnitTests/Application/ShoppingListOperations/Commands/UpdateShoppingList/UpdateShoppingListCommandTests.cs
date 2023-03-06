using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.ShoppingListOperations.Commands.UpdateShoppingList;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ShoppingListOperations.Commands.UpdateShoppingList
{
    public class UpdateShoppingListCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly OnlineStoreDbContext _context;
        public UpdateShoppingListCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenShoppingListIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            UpdateShoppingListCommand command =new UpdateShoppingListCommand(_context);
            command.ShoppingListId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Shopping List not found.");

        }
        [Fact]
        public void WhenValidInputsAreGiven_ShoppingList_ShouldBeUpdated()
        {
            //arrange
            UpdateShoppingListCommand command =new UpdateShoppingListCommand(_context);
            UpdateShoppingListModel model = new UpdateShoppingListModel(){Quantity =1,Price=200};
            command.Model = model;
            command.ShoppingListId=2;
            //act
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            //assert
            var product=_context.ShoppingLists.SingleOrDefault(a=> a.Id == command.ShoppingListId);
            product.Should().NotBeNull();
            product.Quantity.Should().Be(model.Quantity);
            product.Price.Should().Be(model.Price);
    }
    }
}