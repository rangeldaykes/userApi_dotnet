using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases.Autenticate
{
    public class AuthenticateCommand : IRequest<Result<UserDTOAutenticate>>
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
