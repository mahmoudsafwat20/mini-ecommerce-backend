using Mapster;
using mini_ecommerce_backend.Domain.DTOs.Request;
using mini_ecommerce_backend.Domain.DTOs.Response;
using mini_ecommerce_backend.Domain.Interfaces;
using mini_ecommerce_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ecommerce_backend.Infrastructure.Services
{
    public class CreateProduct : ICreateProduct
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateProduct(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<int>> CreateProductAsync(ProductRequest productRequest)
        {
            var product = productRequest.Adapt<Product>();
            if(product.Price<=0 ||  product.Quantity<0)
                return await BaseResponse<int>.FailureAsync("Incorrect values");
           await _unitOfWork.Products.CreateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return await BaseResponse<int>.SuccessAsync("Done");
        }
    }
}
