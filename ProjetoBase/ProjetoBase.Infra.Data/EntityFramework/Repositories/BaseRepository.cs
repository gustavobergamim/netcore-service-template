using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoBase.Application.Repositories;
using ProjetoBase.Domain.Model;

namespace ProjetoBase.Infra.Data.EntityFramework.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IDomainEntity
    {
        protected readonly ProjetoBaseDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(ProjetoBaseDbContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var entry = await DbSet.AddAsync(entity);
            entry.State = EntityState.Modified;
        }
    }
}
