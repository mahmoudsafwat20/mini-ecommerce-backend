using mini_ecommerce_backend.Domain.DTOs.Request;
using mini_ecommerce_backend.Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ecommerce_backend.Domain.Interfaces
{
    public interface ICreateProduct
    {
        Task<BaseResponse<int>> CreateProductAsync(ProductRequest productRequest);

    }
}
