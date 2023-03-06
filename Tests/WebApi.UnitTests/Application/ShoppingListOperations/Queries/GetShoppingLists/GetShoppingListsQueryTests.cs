using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.ShoppingListOperations.Queries.GetShoppingLists;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ShoppingListOperations.Queries.GetShoppingLists
{
    public class GetShoppingListsQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly OnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetShoppingListsQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGetShoppingListsQuery_ShoppingList_ShouldBeReturned()
        {
            // Arrange
            var query = new GetShoppingListsQuery(_context, _mapper);

            // Act
        var result = query.Handle();

            // Assert
            result.Should().NotBeNull();
            result[0].Quantity.Should().Be(1);
            result[0].Price.Should().Be(100);
            result[0].ShoppingDate.Should().Be(new DateTime(2022,03,06));

            result[1].Price.Should().Be(200);
            result[1].Quantity.Should().Be(1);
            result[1].ShoppingDate.Should().Be(new DateTime(2022,06,06));

            result[2].Price.Should().Be(100);
            result[2].Quantity.Should().Be(2);
            result[2].ShoppingDate.Should().Be(new DateTime(2022,07,06));


        }
    }
}