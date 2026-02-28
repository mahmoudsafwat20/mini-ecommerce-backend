using mini_ecommerce_backend.Domain.Interfaces;
using mini_ecommerce_backend.Domain.Interfaces.Repo;
using mini_ecommerce_backend.Domain.Models;
using mini_ecommerce_backend.Presistance.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace mini_ecommerce_backend.Presistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Product> _product;
        private readonly IRepository<Order> _order;
        private readonly IRepository<Customer> _customer;
        public UnitOfWork(ApplicationDbContext context, IRepository<Product> product, IRepository<Order> order, IRepository<Customer> customer)
        {
            _context = context;
            _product = product;
            _order = order;
            _customer = customer;
        }
        public IRepository<Order> Orders { get; private set; }

        public IRepository<Product> Products { get; private set; }

        public IRepository<Customer> Customers { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
