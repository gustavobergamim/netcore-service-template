using System;
using System.Collections.Generic;
using ProjetoBase.Domain.ValueObjects;

namespace ProjetoBase.Domain.Queries
{
    public class PagingQueryResult<T>
    {
        public IReadOnlyCollection<T> Content { get; }
        public int TotalElements { get; }
        public int Take { get; } = 10;
        public int NumberOfElements { get; }
        public int TotalPages => Take.Equals(0) ? 1 : (NumberOfElements / Take);
        public string Sort { get; set; }

        public PagingQueryResult(List<T> content, int numberOfElements, int take, Sort sort)
        {
            Content = content;
            TotalElements = content.Count;
            Take = take;
            NumberOfElements = numberOfElements;
            Sort = sort;
        }

        public PagingQueryResult(List<T> content, Sort sort)
        {
            Content = content;
            TotalElements = content.Count;
            NumberOfElements = content.Count;
            Sort = sort;
        }

        public PagingQueryResult(List<T> content) : this(content, String.Empty) { }
    }
}