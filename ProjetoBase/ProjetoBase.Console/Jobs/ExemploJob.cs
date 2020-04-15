using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjetoBase.Console.JobRunner;

namespace ProjetoBase.Console.Jobs
{
    internal class ExemploJob : IJob
    {
        private readonly IMediator _mediator;

        public ExemploJob(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            //await _mediator.Send(new ExemploCommand(), cancellationToken);
            await Task.CompletedTask;
        }
    }
}

