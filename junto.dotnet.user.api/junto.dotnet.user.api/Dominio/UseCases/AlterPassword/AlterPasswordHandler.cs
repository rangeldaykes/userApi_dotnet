using FluentValidation;
using junto.dotnet.user.api.Dominio.Repositories;
using junto.dotnet.user.api.Dominio.UseCases.AlterPassWord;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases.AlterPassword
{
    public class AlterPasswordHandler : IRequestHandler<AlterPasswordCommand, Result>
    {
        private readonly IUserRepository _repositoryUser;

        public AlterPasswordHandler(
            IUserRepository repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public async Task<Result> Handle(AlterPasswordCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return new Result(request.ValidationResult.Errors.Select(x => x.ErrorMessage).ToList());

            var user = await _repositoryUser.GetByEmail(request.Email);

            _ = await _repositoryUser.ChangePassword(request.Id, request.newPassword);

            return Result.Fact;
        }
    }
}
