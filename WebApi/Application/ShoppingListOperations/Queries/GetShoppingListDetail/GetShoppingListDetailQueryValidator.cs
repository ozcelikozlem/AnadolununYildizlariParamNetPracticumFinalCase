using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ShoppingListOperations.Queries.GetShoppingListDetail
{
    public class GetShoppingListDetailQueryValidator : AbstractValidator<GetShoppingListDetailQuery>
    {
        public GetShoppingListDetailQueryValidator()
        {
            RuleFor(query => query.ShoppingListId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}