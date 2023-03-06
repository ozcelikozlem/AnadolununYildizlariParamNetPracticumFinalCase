using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.CategoryOperations.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQueryValidator : AbstractValidator<GetCategoryDetailQuery>
    {
        public GetCategoryDetailQueryValidator()
        {
            RuleFor(query => query.CategoryId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}