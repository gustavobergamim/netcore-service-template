using System;
using System.Linq.Expressions;
using System.Text.Json.Serialization;
using ProjetoBase.Domain.Model;
using ProjetoBase.Domain.ValueObjects;

namespace ProjetoBase.Domain.Queries
{
    public abstract class BaseQueryParams<T> where T : IDomainEntity
    {

        public BaseQueryParams()
        {
            PageSize = 10;
            Direction = "ASC";
            SortProp = OrderCommand("");
        }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public Sort Direction { get; set; }
        public string OrderBy
        {
            set => SortProp = OrderCommand(value?.ToUpper());
        }

        [JsonIgnore]
        public Expression<Func<T, object>> SortProp { get; protected set; }

        protected abstract Expression<Func<T, object>> OrderCommand(string value);
    }
}