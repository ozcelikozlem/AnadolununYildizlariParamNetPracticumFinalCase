using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ProductShoppingListOperations.Queries.GetProductShoppingListDetail
{
    public class GetProductShoppingListDetailQueryValidator : AbstractValidator<GetProductShoppingListDetailQuery>
    {
        public GetProductShoppingListDetailQueryValidator()
        {
            RuleFor(query => query.ProductShoppingListId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}