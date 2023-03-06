using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ShoppingListOperations.Commands.DeleteShoppingList
{
    public class DeleteShoppingListCommandValidator : AbstractValidator<DeleteShoppingListCommand>
    {
        public DeleteShoppingListCommandValidator()
        {
            RuleFor(command => command.ShoppingListId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}