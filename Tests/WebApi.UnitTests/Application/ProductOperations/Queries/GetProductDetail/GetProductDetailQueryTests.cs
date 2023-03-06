using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.ProductOperations.Queries.GetProductDetail;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ProductOperations.Queries.GetProductDetail
{
    public class GetProductDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetProductDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenProductIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            GetProductDetailQuery query =new GetProductDetailQuery(_context,_mapper);
            query.ProductId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Product not found.");

        }

         [Fact]
        public void WhenValidInputsAreGiven_Product_ShouldBeReturned()
        {
            // arrange
            GetProductDetailQuery query = new(_context, _mapper);
            query.ProductId = 1;

            var product= _context.Products.SingleOrDefault(b => b.Id == query.ProductId);

            // act
            ProductDetailViewModel vm = query.Handle();

            // assert
            vm.Should().NotBeNull();
            vm.Title.Should().Be(product.Title);
        }
    }
}