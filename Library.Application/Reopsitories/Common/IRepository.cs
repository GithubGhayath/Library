using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Library.Application.Reopsitories.Common
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T,bool>>?Filter=null, Func<IQueryable<T>, IQueryable<T>>? include = null);
        T? Get(Expression<Func<T, bool>> Filter, Func<IQueryable<T>, IQueryable<T>>? include = null);
        void Add(T entity);
        void AddRange(List<T> entities);
        void Remove(T entity);
        bool IsExist(Expression<Func<T, bool>> Filter);
    }
}
