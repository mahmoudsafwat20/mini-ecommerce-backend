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
    public class GetOrder : IGetOrder
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetOrder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<Order>> GetOrderByIdAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetOneAsync(b => b.Id == id);
            if(order == null) 
                return await BaseResponse<Order>.FailureAsync("Not Found");
            return await BaseResponse<Order>.SuccessAsync(order);
        }
    }
}
