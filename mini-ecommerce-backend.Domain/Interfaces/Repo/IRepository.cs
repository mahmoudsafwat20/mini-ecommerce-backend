using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mini_ecommerce_backend.Domain.Interfaces.Repo
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<List<T>> GetAsync(Expression<Func<T, bool>>? expression = null,
                              Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                              bool tracked = true);
        Task<T?> GetOneAsync(Expression<Func<T, bool>>? expression = null,
                            bool tracked = true);
        IQueryable<T> GetQueryable(Expression<Func<T, bool>>? expression = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                  bool tracked = true);
    }
}
