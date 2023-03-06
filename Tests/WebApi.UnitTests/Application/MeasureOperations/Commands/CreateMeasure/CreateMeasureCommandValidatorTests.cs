using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.MeasureOperations.Commands.CreateMeasure;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MeasureOperations.Commands.CreateMeasure
{
    public class CreateMeasureCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lor")]
        [InlineData(" ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title)
        {
            //arrange
           CreateMeasureCommand command = new CreateMeasureCommand(null,null);
           command.Model =new CreateMeasureModel()
           {
                Title=title
           };

            //act
            CreateMeasureCommandValidator validator = new CreateMeasureCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            CreateMeasureCommand command = new CreateMeasureCommand(null,null);
            command.Model =new CreateMeasureModel()
            {
                Title="title"
            };

            //act
            CreateMeasureCommandValidator validator = new CreateMeasureCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}