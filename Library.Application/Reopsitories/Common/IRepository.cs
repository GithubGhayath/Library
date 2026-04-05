using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Library.Application.Reopsitories.Common
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T,bool>>?Filter=null,string[]? includeProperties= null);
        T? Get(Expression<Func<T, bool>> Filter, string[]? includeProperties = null);
        void Add(T entity);
        void AddRange(List<T> entities);
        void Remove(T entity);
        bool IsExist(Expression<Func<T, bool>> Filter);
    }
}
