using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.ProductOperations.Queries.GetProducts;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ProductOperations.Queries.GetProducts
{
    public class GetProductsQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly OnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetProductsQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGetProductsQuery_ProductList_ShouldBeReturned()
        {
            // Arrange
            var query = new GetProductsQuery(_context, _mapper);

            // Act
        var result = query.Handle();

            // Assert
            result.Should().NotBeNull();

            result[0].Title.Should().Be("Pants");
            result[0].Price.Should().Be(100);
            result[0].ProductDate.Should().Be(new DateTime(2022,03,06));

            result[1].Title.Should().Be("Cherry");
            result[1].Price.Should().Be(60);
            result[1].ProductDate.Should().Be(new DateTime(2022,06,03));


            result[2].Title.Should().Be("Fountain Pen");
            result[2].Price.Should().Be(45);
            result[2].ProductDate.Should().Be(new DateTime(2022,09,07));


        }
    }
}