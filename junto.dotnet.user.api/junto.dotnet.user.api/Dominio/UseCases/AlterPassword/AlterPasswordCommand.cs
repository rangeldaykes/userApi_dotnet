using junto.dotnet.user.api.Dominio.UseCases.AlterPassword;
using MediatR;

namespace junto.dotnet.user.api.Dominio.UseCases.AlterPassWord
{
    public class AlterPasswordCommand : Command, IRequest<Result>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AlterPasswordValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
