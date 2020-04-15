using System.Threading;
using System.Threading.Tasks;

namespace ProjetoBase.Console.JobRunner
{
    public interface IJob
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}