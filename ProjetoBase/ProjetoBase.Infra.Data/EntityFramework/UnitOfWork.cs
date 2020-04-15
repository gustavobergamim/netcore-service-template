using System.Threading.Tasks;
using ProjetoBase.Application.Repositories;

namespace ProjetoBase.Infra.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjetoBaseDbContext _context;

        public UnitOfWork(ProjetoBaseDbContext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
