using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.CategoryOperations.Queries.GetCategoryDetail;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.CategoryOperations.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCategoryDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenCategoryIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            GetCategoryDetailQuery query =new GetCategoryDetailQuery(_context,_mapper);
            query.CategoryId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Category not found.");

        }

         [Fact]
        public void WhenValidInputsAreGiven_Category_ShouldBeReturned()
        {
            // arrange
            GetCategoryDetailQuery query = new(_context, _mapper);
            query.CategoryId = 1;

            var category = _context.Categories.SingleOrDefault(b => b.Id == query.CategoryId);

            // act
            CategoryDetailViewModel vm = query.Handle();

            // assert
            vm.Should().NotBeNull();
            vm.Title.Should().Be(category.Title);
        }

    }
}