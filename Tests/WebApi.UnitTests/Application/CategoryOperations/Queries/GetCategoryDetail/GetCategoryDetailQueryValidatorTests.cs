using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.CategoryOperations.Queries.GetCategoryDetail;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.CategoryOperations.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenCategoryIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int cId )
        {
            //arrange
           GetCategoryDetailQuery query = new GetCategoryDetailQuery(null,null);
           query.CategoryId = cId;

            //act
             GetCategoryDetailQueryValidator validator = new GetCategoryDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenCategoryIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           GetCategoryDetailQuery query = new GetCategoryDetailQuery(null,null);
           query.CategoryId = 3;

            //act
            GetCategoryDetailQueryValidator validator = new GetCategoryDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}