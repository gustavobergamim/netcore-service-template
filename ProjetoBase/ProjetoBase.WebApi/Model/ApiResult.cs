using System.Collections.Generic;
using ProjetoBase.Domain.Commands;

namespace ProjetoBase.WebApi.Model
{
    public class ApiResult
    {
        public bool IsValid { get; private set; }
        public IReadOnlyDictionary<string, IReadOnlyList<string>> Validations { get; private set; }
        public IReadOnlyList<string> Errors { get; private set; }
        public IReadOnlyList<string> Messages { get; private set; }

        public object Result { get; set; }

        public static implicit operator ApiResult(CommandResult result)
        {
            return new ApiResult
            {
                IsValid = result.IsValid,
                Validations = result.ListValidations(),
                Errors = result.ListErrors(),
                Messages = result.ListMessages(),
                Result = result.Model
            };
        }
    }
}
