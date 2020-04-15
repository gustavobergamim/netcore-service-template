using MediatR;

namespace ProjetoBase.Domain.Commands
{
    public interface ICommand<out TResult> : IRequest<TResult>
        where TResult : CommandResult
    {
        
    }
}