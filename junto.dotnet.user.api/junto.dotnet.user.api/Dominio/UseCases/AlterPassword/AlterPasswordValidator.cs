using FluentValidation;
using junto.dotnet.user.api.Dominio.UseCases.AlterPassWord;

namespace junto.dotnet.user.api.Dominio.UseCases.AlterPassword
{
    public class AlterPasswordValidator : AbstractValidator<AlterPasswordCommand>
    {
        public AlterPasswordValidator()
        {
            RuleFor(model => model.Email).NotEmpty().WithMessage(FriendlyMessages.EMAIL_EMPTY)
                .EmailAddress().WithMessage(FriendlyMessages.EMAIL_VALID);

            RuleFor(model => model.oldPassword).NotEqual(x => x.newPassword).WithMessage(FriendlyMessages.ALTERPASSWORD_NOT_EQUAL);

            RuleFor(model => model.newPassword.Length).GreaterThan(5).WithMessage(
                string.Format(FriendlyMessages.ALTERPASSWORD_PASS_GREATER, 6));
        }
    }
}