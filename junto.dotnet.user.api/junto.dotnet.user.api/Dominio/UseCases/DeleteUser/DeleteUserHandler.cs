using junto.dotnet.user.api.Dominio.Entities;
using junto.dotnet.user.api.Dominio.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result>
    {
        private readonly IUserRepository _repositoryUser;

        public DeleteUserHandler(IUserRepository repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {           
            var user = await _repositoryUser.Delete(request.Id);

            return Result.Fact;
        }
    }
}
