using junto.dotnet.user.api.Dominio.Entities;
using junto.dotnet.user.api.Dominio.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result>
    {
        private readonly IUserRepository _repositoryUser;

        public UpdateUserHandler(IUserRepository repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userEnt = new UserEntity { Id = request.Id, Name = request.Nome, Email = request.Email };

            var user = await _repositoryUser.UpdateFields(userEnt);

            return Result.Fact;
        }
    }
}
