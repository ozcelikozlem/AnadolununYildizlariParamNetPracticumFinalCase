using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ProductOperations.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(command => command.Model.CategoryId).GreaterThan(0);
            RuleFor(command => command.Model.MeasureId).GreaterThan(0);
            RuleFor(command => command.Model.Price).GreaterThan(0);
            RuleFor(command => command.Model.ProductTitle).NotEmpty().MinimumLength(4);
        }
    }
}