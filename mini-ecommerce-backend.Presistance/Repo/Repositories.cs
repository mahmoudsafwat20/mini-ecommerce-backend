using Microsoft.EntityFrameworkCore;
using mini_ecommerce_backend.Domain.Interfaces.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mini_ecommerce_backend.Presistance.Repo
{
    public class Repositories<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _db;

        public Repositories(ApplicationDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _db.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _db.Remove(entity);
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool tracked = true)
        {
            IQueryable<T> query = _db;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }
        public IQueryable<T> GetQueryable(Expression<Func<T, bool>>? expression = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                       bool tracked = true)
        {
            IQueryable<T> query = _db;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        public async Task<T?> GetOneAsync(Expression<Func<T, bool>>? expression = null, bool tracked = true)
        {
            IQueryable<T> query = _db;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (expression != null)
            {
                query = query.Where(expression);
            }

            return await query.FirstOrDefaultAsync();
        }

        public void Update(T entity)
        {
            _db.Update(entity);
        }
    }
}
