using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.CategoryOperations.Queries.GetCategories;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.CategoryOperations.Queries.GetCategories
{
    public class GetCategoriesQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly OnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCategoriesQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGetCategoriesQuery_CategoryList_ShouldBeReturned()
        {
            // Arrange
            var query = new GetCategoriesQuery(_context, _mapper);

            // Act
        var result = query.Handle();

            // Assert
            result.Should().NotBeNull();

            result[0].Title.Should().Be("Food");
            result[1].Title.Should().Be("Book");
            result[2].Title.Should().Be("Stationery");
            result[3].Title.Should().Be("Clothes");

        }
    }
}