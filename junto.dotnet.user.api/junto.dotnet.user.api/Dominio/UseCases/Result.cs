using System.Collections.Generic;

namespace junto.dotnet.user.api.Dominio.UseCases
{
    public class Result
    {
        public static Result Fact = new Result();

        public bool HasValidation => _validations.Count > 0;
        private List<string> _validations = new List<string>();
        public IList<string> Validations => _validations;
        public Result() { }

        public Result(IList<string> validations)
        {
            AddValidationRange(validations);
        }

        public void AddValidation(string validation)
            => _validations.Add(validation);

        public void AddValidationRange(IList<string> validation)
            => _validations.AddRange(validation);
    }

    public class Result<TResponse> : Result
    {
        public TResponse Data { get; private set; }
        public Result() { }

        public Result(TResponse data)
        {
            Data = data;
        }
        public Result(TResponse data, IList<string> validations)
        {
            Data = data;
            AddValidationRange(validations);
        }
    }
}
