using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases.AddUser
{
    public class UserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public UserCommandValidator()
        {
            RuleFor(model => model.Email).NotEmpty().WithMessage(FriendlyMessages.EMAIL_EMPTY)
                .EmailAddress().WithMessage(FriendlyMessages.EMAIL_VALID);

            RuleFor(model => model.Nome).NotEmpty().WithMessage(FriendlyMessages.NAME_EMPTY);
        }
    }
}