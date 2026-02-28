using Mapster;
using mini_ecommerce_backend.Domain.DTOs.Request;
using mini_ecommerce_backend.Domain.DTOs.Response;
using mini_ecommerce_backend.Domain.Interfaces;
using mini_ecommerce_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ecommerce_backend.Infrastructure.Services
{
    public class CreateOrder : ICreateOrder
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<int>> CreateOrderAsync(OrederRequest orederRequest)
        {
            if (orederRequest == null || orederRequest.itemRequests == null || !orederRequest.itemRequests.Any())
                return await BaseResponse<int>.FailureAsync("Order must contain items");

            //  Get product ids
            var productIds = orederRequest.itemRequests
                                          .Select(x => x.Id)
                                          .Distinct()
                                          .ToList();

            //  Fetch products from database
            var products = await _unitOfWork.Products
                                            .GetAsync(p => productIds.Contains(p.Id));

            var productList = products.ToList();

            if (productList.Count != productIds.Count)
                return await BaseResponse<int>.FailureAsync("Some products not found");

            //  Calculate total price BEFORE discount
            decimal totalPrice = 0;

            foreach (var item in orederRequest.itemRequests)
            {
                var product = productList.First(p => p.Id == item.Id);
                totalPrice += product.Price * item.Quantity;
            }

            //  Apply discount based on quantity
            int count = orederRequest.itemRequests.Sum(x => x.Quantity);

            decimal discountRate = 0;

            if (count >= 2 && count <= 4)
                discountRate = 0.05m;
            else if (count >= 5)
                discountRate = 0.10m;

            totalPrice -= totalPrice * discountRate;

            //  Create Order object
            var order = new Order
            {
                Customer = orederRequest.customerRequest.Adapt<Customer>(),
                Products = productList,
                NumberOfItems = count,
                TotalPrice = totalPrice
            };

            //  Save
            await _unitOfWork.Orders.CreateAsync(order);
            await _unitOfWork.SaveChangesAsync();

            return await BaseResponse<int>.SuccessAsync(order.Id, "Order created successfully");
        }
    }
}
