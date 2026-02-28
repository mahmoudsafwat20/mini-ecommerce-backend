using mini_ecommerce_backend.Domain.Interfaces.Repo;
using mini_ecommerce_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ecommerce_backend.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        IRepository<Order> Orders { get; }
        IRepository<Product> Products { get; }
        IRepository<Customer> Customers { get; }
    }
}
