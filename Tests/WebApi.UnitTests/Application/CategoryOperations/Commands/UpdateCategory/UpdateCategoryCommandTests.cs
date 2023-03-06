using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.CategoryOperations.Commands.UpdateCategory;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.CategoryOperations.Commands.UpdateCategory
{
    public class UpdateCategoryCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly OnlineStoreDbContext _context;
        public UpdateCategoryCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenCategoryIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            UpdateCategoryCommand command =new UpdateCategoryCommand(_context);
            command.CategoryId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Category not found.");

        }
        [Fact]
        public void WhenValidInputsAreGiven_Category_ShouldBeUpdated()
        {
            //arrange
            UpdateCategoryCommand command =new UpdateCategoryCommand(_context);
            UpdateCategoryModel model = new UpdateCategoryModel(){CategoryTitle ="Tests"};
            command.Model = model;
            command.CategoryId=3;
            //act
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            //assert
            var category=_context.Categories.SingleOrDefault(a=> a.Id == command.CategoryId);
            category.Should().NotBeNull();
            category.Title.Should().Be(model.CategoryTitle);

        }
    }
}