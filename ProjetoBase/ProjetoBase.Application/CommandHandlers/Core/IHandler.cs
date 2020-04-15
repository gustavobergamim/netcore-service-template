using MediatR;
using ProjetoBase.Domain.Commands;

namespace ProjetoBase.Application.CommandHandlers.Core
{
    public interface IHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
        where TResult : CommandResult
    {

    }
}