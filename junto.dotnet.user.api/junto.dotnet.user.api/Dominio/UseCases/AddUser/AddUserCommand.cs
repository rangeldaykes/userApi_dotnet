using junto.dotnet.user.api.Dominio.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases.AddUser
{
    public class AddUserCommand : UserCommand, IRequest<Result<UserEntity>>
    {
        public override bool IsValid()
        {
            ValidationResult = new UserCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
