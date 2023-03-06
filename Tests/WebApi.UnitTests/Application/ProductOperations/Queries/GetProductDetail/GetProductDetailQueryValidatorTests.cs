using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.ProductOperations.Queries.GetProductDetail;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ProductOperations.Queries.GetProductDetail
{
    public class GetProductDetailQueryValidatorTests  : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenProductIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int pId )
        {
            //arrange
           GetProductDetailQuery query = new GetProductDetailQuery(null,null);
           query.ProductId= pId;

            //act
             GetProductDetailQueryValidator validator = new GetProductDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenProductIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           GetProductDetailQuery query = new GetProductDetailQuery(null,null);
           query.ProductId = 3;

            //act
            GetProductDetailQueryValidator validator = new GetProductDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}