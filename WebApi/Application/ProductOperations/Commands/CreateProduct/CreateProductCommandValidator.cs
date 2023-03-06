using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ProductOperations.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(command => command.Model.CategoryId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.MeasureId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.Price).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.Title).NotEmpty().NotNull().MinimumLength(4);
        }
    }
}