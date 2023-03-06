using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.CategoryOperations.Commands.CreateCategory;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly OnlineStoreDbContext context;
        private readonly IMapper mapper;

        public CreateCategoryCommandTests(CommonTestFixture testFixture)
        {
            this.context = testFixture.Context;
            this.mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExitsCategoryTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // arrange (Hazırlık)
            var category = new Category()
            {
                Title="Tests"
            };
            context.Categories.Add(category);
            context.SaveChanges();

            CreateCategoryCommand command = new(context, mapper);
            command.Model = new CreateCategoryModel { Title = category.Title };

            // act & assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Category already exists.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_roduct_ShouldBeCreated()
        {
            // arrange
            CreateCategoryCommand command = new(context, mapper);
            CreateCategoryModel model = new CreateCategoryModel()
            {
                Title="Tests"
            };

            command.Model = model;

            // act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            // assert
            var category = context.Categories.SingleOrDefault(g => g.Title == model.Title);
            category.Should().NotBeNull();
            category.Title.Should().Be(model.Title);
            }
    }
}