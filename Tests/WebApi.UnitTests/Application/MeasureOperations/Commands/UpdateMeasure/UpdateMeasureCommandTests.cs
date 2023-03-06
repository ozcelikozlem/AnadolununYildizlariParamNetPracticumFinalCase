using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.MeasureOperations.Commands.UpdateMeasure;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MeasureOperations.Commands.UpdateMeasure
{
    public class UpdateMeasureCommandTests : IClassFixture<CommonTestFixture>
    {
         private readonly OnlineStoreDbContext _context;
        public UpdateMeasureCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenMeasureIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            UpdateMeasureCommand command =new UpdateMeasureCommand(_context);
            command.MeasureId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Measure not found.");

        }
        [Fact]
        public void WhenValidInputsAreGiven_Category_ShouldBeUpdated()
        {
            //arrange
            UpdateMeasureCommand command =new UpdateMeasureCommand(_context);
            UpdateMeasureModel model = new UpdateMeasureModel(){MeasureTitle ="Test"};
            command.Model = model;
            command.MeasureId=3;
            //act
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            //assert
            var category=_context.Measures.SingleOrDefault(a=> a.Id == command.MeasureId);
            category.Should().NotBeNull();
            category.Title.Should().Be(model.MeasureTitle);

        }
    }
}