using mini_ecommerce_backend.Domain.DTOs.Request;
using mini_ecommerce_backend.Domain.DTOs.Response;
using mini_ecommerce_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ecommerce_backend.Domain.Interfaces
{
    public interface IListProducts1
    {
        Task<PaginatedResponse<Product>> GetAllProductsAsync(PaginatedRequest Request);
    }
}
