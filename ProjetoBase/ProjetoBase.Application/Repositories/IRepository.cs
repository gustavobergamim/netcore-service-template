using System.Threading.Tasks;
using ProjetoBase.Domain.Model;

namespace ProjetoBase.Application.Repositories
{
    public interface IRepository<in TEntity> where TEntity : IDomainEntity
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(object id);
    }
}