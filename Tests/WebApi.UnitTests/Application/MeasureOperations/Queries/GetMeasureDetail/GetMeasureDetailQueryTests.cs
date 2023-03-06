using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.MeasureOperations.Queries.GetMeasureDetail;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MeasureOperations.Queries.GetMeasureDetail
{
    public class GetMeasureDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMeasureDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenMeasureIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            GetMeasureDetailQuery query =new GetMeasureDetailQuery(_context,_mapper);
            query.MeasureId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Measure not found.");

        }

         [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeReturned()
        {
            // arrange
            GetMeasureDetailQuery query = new(_context, _mapper);
            query.MeasureId = 1;

            var measure = _context.Measures.SingleOrDefault(b => b.Id == query.MeasureId);

            // act
            MeasureDetailViewModel vm = query.Handle();

            // assert
            vm.Should().NotBeNull();
            vm.Title.Should().Be(measure.Title);
        }

    }
}