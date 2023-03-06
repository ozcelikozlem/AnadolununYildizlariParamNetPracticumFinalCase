using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.MeasureOperations.Commands.UpdateMeasure
{
    public class UpdateMeasureCommandValidator : AbstractValidator<UpdateMeasureCommand>
    {
        public UpdateMeasureCommandValidator()
        {
            RuleFor(command => command.Model.MeasureTitle).MinimumLength(4).When(x => x.Model.MeasureTitle != string.Empty);
        }
    }
}