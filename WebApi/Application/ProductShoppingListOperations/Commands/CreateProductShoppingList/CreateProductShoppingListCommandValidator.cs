using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ProductShoppingListOperations.Commands.CreateProductShoppingList
{
    public class CreateProductShoppingListCommandValidator : AbstractValidator<CreateProductShoppingListCommand>
    {
        public CreateProductShoppingListCommandValidator()
        {
            RuleFor(command => command.Model.ProductId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.ShoppingListId).NotEmpty().GreaterThan(0);
        }
    }
}