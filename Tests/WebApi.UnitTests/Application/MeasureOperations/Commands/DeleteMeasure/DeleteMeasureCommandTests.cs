using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.MeasureOperations.Commands.DeleteMeasure;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MeasureOperations.Commands.DeleteMeasure
{
    public class DeleteMeasureCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly OnlineStoreDbContext _context;
        public DeleteMeasureCommandTests(CommonTestFixture testFixture)
        {
          _context = testFixture.Context;
        }

         [Fact]
        public void WhenGivenMeasureIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            DeleteMeasureCommand command =new DeleteMeasureCommand(_context);
            command.MeasureId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Measure not found.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeDeleted()
        {
            //arrange
            DeleteMeasureCommand command =new DeleteMeasureCommand(_context);
            command.MeasureId=1;

            //act
             DeleteMeasureCommandValidator validator = new DeleteMeasureCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}