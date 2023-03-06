using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.MeasureOperations.Queries.GetMeasures;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MeasureOperations.Queries.GetMeasures
{
    public class GetMeasuresQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly OnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMeasuresQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGetMeasuresQuery_MeasureList_ShouldBeReturned()
        {
            // Arrange
            var query = new GetMeasuresQuery(_context, _mapper);

            // Act
        var result = query.Handle();

            // Assert
            result.Should().NotBeNull();

            result[0].Title.Should().Be("kg");
            result[1].Title.Should().Be("gr");
            result[2].Title.Should().Be("lt");
            result[3].Title.Should().Be("piece");

        }
    }
}