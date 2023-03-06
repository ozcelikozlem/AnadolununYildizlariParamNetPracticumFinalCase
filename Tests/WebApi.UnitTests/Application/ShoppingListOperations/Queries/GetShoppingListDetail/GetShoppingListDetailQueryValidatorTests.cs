using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.ShoppingListOperations.Queries.GetShoppingListDetail;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ShoppingListOperations.Queries.GetShoppingListDetail
{
    public class GetShoppingListDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenProductIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int pId )
        {
            //arrange
           GetShoppingListDetailQuery query = new GetShoppingListDetailQuery(null,null);
           query.ShoppingListId= pId;

            //act
             GetShoppingListDetailQueryValidator validator = new GetShoppingListDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenProductIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           GetShoppingListDetailQuery query = new GetShoppingListDetailQuery(null,null);
           query.ShoppingListId = 3;

            //act
            GetShoppingListDetailQueryValidator validator = new GetShoppingListDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}