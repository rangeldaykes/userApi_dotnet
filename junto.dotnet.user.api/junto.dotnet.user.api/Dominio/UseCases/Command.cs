
using FluentValidation.Results;

namespace junto.dotnet.user.api.Dominio.UseCases
{
    public abstract class Command
    {
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}
