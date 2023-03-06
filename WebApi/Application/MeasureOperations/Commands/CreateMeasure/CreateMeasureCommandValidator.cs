using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.MeasureOperations.Commands.CreateMeasure
{
    public class CreateMeasureCommandValidator : AbstractValidator<CreateMeasureCommand>
    {
        public CreateMeasureCommandValidator()
        {
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}