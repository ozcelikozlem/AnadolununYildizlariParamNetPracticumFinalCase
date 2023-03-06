using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.MeasureOperations.Queries.GetMeasureDetail;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MeasureOperations.Queries.GetMeasureDetail
{
    public class GetMeasureDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenCategoryIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int mId )
        {
            //arrange
           GetMeasureDetailQuery query = new GetMeasureDetailQuery(null,null);
           query.MeasureId = mId;

            //act
             GetMeasureDetailQueryValidator validator = new GetMeasureDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenMeasureIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           GetMeasureDetailQuery query = new GetMeasureDetailQuery(null,null);
           query.MeasureId = 3;

            //act
            GetMeasureDetailQueryValidator validator = new GetMeasureDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}