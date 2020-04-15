using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using ProjetoBase.Domain.Commands;

namespace ProjetoBase.Infra.Bus
{
    public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse> 
        where TResponse : CommandResult, new()
    {
        private readonly IEnumerable<IValidator> _validators;

        public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validations = _validators.Select(v=>v.Validate(request)).ToList();
            if (validations.All(v => v.IsValid)) return await next();
            var result = new TResponse();
            result.AddValidations(validations);
            return result;
        }
    }
}
