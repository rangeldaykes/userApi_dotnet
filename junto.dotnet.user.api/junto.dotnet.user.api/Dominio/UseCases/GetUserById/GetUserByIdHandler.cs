using junto.dotnet.user.api.Dominio.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdCommand, Result<UserDTO>>
    {
        private readonly IUserRepository _repositoryUser;

        public GetUserByIdHandler(IUserRepository repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public async Task<Result<UserDTO>> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _repositoryUser.GetById(request.Id);

            UserDTO ret;
            ret = user != null ? new UserDTO { Nome = user.Name, Email = user.Email } : null;

            return new Result<UserDTO>(ret);
        }
    }
}
