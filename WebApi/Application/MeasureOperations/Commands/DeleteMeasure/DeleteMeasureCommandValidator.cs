using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.MeasureOperations.Commands.DeleteMeasure
{
    public class DeleteMeasureCommandValidator : AbstractValidator<DeleteMeasureCommand>
    {
        public DeleteMeasureCommandValidator()
        {
            RuleFor(command => command.MeasureId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}