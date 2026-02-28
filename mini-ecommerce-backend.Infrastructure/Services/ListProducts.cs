using mini_ecommerce_backend.Domain.DTOs.Request;
using mini_ecommerce_backend.Domain.DTOs.Response;
using mini_ecommerce_backend.Domain.Interfaces;
using mini_ecommerce_backend.Domain.Models;
using mini_ecommerce_backend.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ecommerce_backend.Infrastructure.Services
{
    public class ListProducts : IListProducts1
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListProducts(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginatedResponse<Product>> GetAllProductsAsync(PaginatedRequest Request)
        {
            var query = _unitOfWork.Products.GetQueryable();

            return await query.ToPaginatedListAsync(
                Request.PageSize,
                Request.PageNumber,
                CancellationToken.None
            );
        }
    }
}
