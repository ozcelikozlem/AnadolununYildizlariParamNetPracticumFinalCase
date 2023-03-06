using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.MeasureOperations.Commands.DeleteMeasure;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MeasureOperations.Commands.DeleteMeasure
{
    public class DeleteMeasureCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenCategoryIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int measureId )
        {
            //arrange
           DeleteMeasureCommand command = new DeleteMeasureCommand(null);
           command.MeasureId = measureId;

            //act
            DeleteMeasureCommandValidator validator = new DeleteMeasureCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenCategoryIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           DeleteMeasureCommand command = new DeleteMeasureCommand(null);
           command.MeasureId = 2;

            //act
            DeleteMeasureCommandValidator validator = new DeleteMeasureCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}