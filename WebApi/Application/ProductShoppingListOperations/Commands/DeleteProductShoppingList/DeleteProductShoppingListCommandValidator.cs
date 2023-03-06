using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ProductShoppingListOperations.Commands.DeleteProductShoppingList
{
    public class DeleteProductShoppingListCommandValidator : AbstractValidator<DeleteProductShoppingListCommand>
    {
        public DeleteProductShoppingListCommandValidator()
        {
            RuleFor(command => command.ProductShoppingListId).NotEmpty().GreaterThan(0);
        }
    }
}