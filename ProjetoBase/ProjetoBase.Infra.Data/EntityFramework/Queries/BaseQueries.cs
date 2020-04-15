using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoBase.Application.Queries;
using ProjetoBase.Domain.Model;
using ProjetoBase.Domain.Queries;
using ProjetoBase.Domain.ValueObjects;

namespace ProjetoBase.Infra.Data.EntityFramework.Queries
{
    public class BaseQueries<TEntity> : IQueries<TEntity> where TEntity : class, IDomainEntity
    {
        protected readonly ProjetoBaseDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseQueries(ProjetoBaseDbContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public ValueTask<TEntity> FindById(object id)
        {
            return DbSet.FindAsync(id);
        }

        public Task<List<TEntity>> List()
        {
            return DbSet.ToListAsync();
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet.AnyAsync(expression);
        }

        protected IOrderedQueryable<T> SortQuery<T>(IQueryable<T> query, BaseQueryParams<T> filter)
            where T : IDomainEntity
        {
            return filter.Direction == Sort.Direction.Asc
                ? query.OrderBy(filter.SortProp)
                : query.OrderByDescending(filter.SortProp);
        }
    }
}
