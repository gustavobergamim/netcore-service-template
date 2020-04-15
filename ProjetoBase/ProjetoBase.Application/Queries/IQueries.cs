using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjetoBase.Domain.Model;

namespace ProjetoBase.Application.Queries
{
    public interface IQueries<TEntity> where TEntity : IDomainEntity
    {
        ValueTask<TEntity> FindById(object id);
        Task<List<TEntity>> List();
        Task<bool> Any(Expression<Func<TEntity, bool>> expression);
    }
}