using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.MeasureOperations.Commands.CreateMeasure;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MeasureOperations.Commands.CreateMeasure
{
    public class CreateMeasureCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly OnlineStoreDbContext context;
        private readonly IMapper mapper;

        public CreateMeasureCommandTests(CommonTestFixture testFixture)
        {
            this.context = testFixture.Context;
            this.mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExitsMeasureTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // arrange (Hazırlık)
            var measure = new Measure()
            {
                Title="Tests"
            };
            context.Measures.Add(measure);
            context.SaveChanges();

            CreateMeasureCommand command = new(context, mapper);
            command.Model = new CreateMeasureModel { Title = measure.Title };

            // act & assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Measure already exists.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Measure_ShouldBeCreated()
        {
            // arrange
            CreateMeasureCommand command = new(context, mapper);
            CreateMeasureModel model = new CreateMeasureModel()
            {
                Title="Tests"
            };

            command.Model = model;

            // act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            // assert
            var measure = context.Measures.SingleOrDefault(g => g.Title == model.Title);
            measure.Should().NotBeNull();
            measure.Title.Should().Be(model.Title);
            }
    }
}