using System.Threading.Tasks;

namespace ProjetoBase.Application.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        void Dispose();
    }
}