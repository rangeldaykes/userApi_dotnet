using FluentValidation;
using junto.dotnet.user.api.Dominio.Entities;
using junto.dotnet.user.api.Dominio.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases.AddUser
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, Result<UserEntity>>
    {
        private readonly IUserRepository _repositoryUser;

        public AddUserHandler(
            IUserRepository repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public async Task<Result<UserEntity>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())                
                return new Result<UserEntity>(null, request.ValidationResult.Errors.Select(x => x.ErrorMessage).ToList());

            var userEnt = new UserEntity { Name = request.Nome, Email = request.Email, Password = request.PassWord };

            var user = await _repositoryUser.Save(userEnt);

            return new Result<UserEntity>(user);
        }
    }
}
