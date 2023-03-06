using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ProductShoppingListOperations.Commands.UpdateProductShoppingList
{
    public class UpdateProductShoppingListCommandValidator : AbstractValidator<UpdateProductShoppingListCommand>
    {
        public UpdateProductShoppingListCommandValidator()
        {
            RuleFor(command => command.Model.ProductId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command => command.Model.ShoppingListId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}