using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.ShoppingListOperations.Queries.GetShoppingListDetail;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ShoppingListOperations.Queries.GetShoppingListDetail
{
    public class GetShoppingListDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetShoppingListDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenShoppingListIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            GetShoppingListDetailQuery query =new GetShoppingListDetailQuery(_context,_mapper);
            query.ShoppingListId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Shopping List not found.");

        }

         [Fact]
        public void WhenValidInputsAreGiven_ShoppingList_ShouldBeReturned()
        {
            // arrange
            GetShoppingListDetailQuery query = new(_context, _mapper);
            query.ShoppingListId = 1;

            var shoppingList= _context.ShoppingLists.SingleOrDefault(b => b.Id == query.ShoppingListId);

            // act
            ShoppingListDetailViewModel vm = query.Handle();

            // assert
            vm.Should().NotBeNull();
            vm.Quantity.Should().Be(shoppingList.Quantity);
            vm.Price.Should().Be(shoppingList.Price);
        }
    }
}