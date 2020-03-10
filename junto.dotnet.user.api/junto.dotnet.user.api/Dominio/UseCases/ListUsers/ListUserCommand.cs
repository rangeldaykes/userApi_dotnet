using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases.ListUsers
{
    public class ListUserCommand : IRequest<Result<List<UserDTO>>>
    {
    }
}
