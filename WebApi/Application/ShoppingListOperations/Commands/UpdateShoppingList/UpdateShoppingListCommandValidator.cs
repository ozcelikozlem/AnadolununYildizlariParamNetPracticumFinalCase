using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ShoppingListOperations.Commands.UpdateShoppingList
{
    public class UpdateShoppingListCommandValidator : AbstractValidator<UpdateShoppingListCommand>
    {
        public UpdateShoppingListCommandValidator()
        {
            RuleFor(command => command.Model.Quantity).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.Price).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.UserId).GreaterThan(0).NotEmpty().NotNull();
            
        }
    }
}