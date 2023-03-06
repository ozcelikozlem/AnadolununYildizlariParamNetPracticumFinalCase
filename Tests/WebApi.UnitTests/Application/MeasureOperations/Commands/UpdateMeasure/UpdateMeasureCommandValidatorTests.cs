using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.MeasureOperations.Commands.UpdateMeasure;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MeasureOperations.Commands.UpdateMeasure
{
    public class UpdateMeasureCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        
        [Theory]
        [InlineData(0,"Lor")]
        [InlineData(0," ")]
        [InlineData(1," ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int mId,string title )
        {
            //arrange
           UpdateMeasureCommand command = new UpdateMeasureCommand(null);
           command.Model =new UpdateMeasureModel()
           {
                MeasureTitle = title
           };
           command.MeasureId = mId;

            //act
            UpdateMeasureCommandValidator validator = new UpdateMeasureCommandValidator();
            var result = validator.Validate(command);

            //assert
            
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            UpdateMeasureCommand command = new UpdateMeasureCommand(null);
            command.Model =new UpdateMeasureModel()
            {
                MeasureTitle = "Tests",

            };
            command.MeasureId = 3;
            
            //act
            UpdateMeasureCommandValidator validator = new UpdateMeasureCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}