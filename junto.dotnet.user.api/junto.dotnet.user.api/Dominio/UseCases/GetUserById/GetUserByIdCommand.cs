using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases.GetUserById
{
    public class GetUserByIdCommand : IRequest<Result<UserDTO>>
    {
        public int Id { get; set; }
    }
}
