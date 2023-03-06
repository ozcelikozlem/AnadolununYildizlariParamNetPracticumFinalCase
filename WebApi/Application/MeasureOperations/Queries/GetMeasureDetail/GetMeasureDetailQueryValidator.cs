using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.MeasureOperations.Queries.GetMeasureDetail
{
    public class GetMeasureDetailQueryValidator : AbstractValidator<GetMeasureDetailQuery>
        {
            public GetMeasureDetailQueryValidator()
            {
                RuleFor(query => query.MeasureId).NotEmpty().NotNull().GreaterThan(0);
            }
        }
    
}