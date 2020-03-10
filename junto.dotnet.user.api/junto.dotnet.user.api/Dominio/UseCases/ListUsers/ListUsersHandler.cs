using junto.dotnet.user.api.Dominio.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases.ListUsers
{
    public class ListUsersHandler : IRequestHandler<ListUserCommand, Result<List<UserDTO>>>
    {
        private readonly IUserRepository _repositoryUser;

        public ListUsersHandler(IUserRepository repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public async Task<Result<List<UserDTO>>> Handle(ListUserCommand request, CancellationToken cancellationToken)
        {
            var users = await _repositoryUser.GetAll();

            var ret = users.Select(u => new UserDTO { Nome = u.Name, Email = u.Email }).ToList();

            return new Result<List<UserDTO>>(ret);
        }
    }
}
 