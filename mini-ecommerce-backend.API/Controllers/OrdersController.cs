using Microsoft.AspNetCore.Mvc;
using mini_ecommerce_backend.Domain.DTOs.Request;
using mini_ecommerce_backend.Domain.Interfaces;

namespace mini_ecommerce_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICreateOrder _createOrder;
        private readonly IGetOrder _getOrder;

        public OrdersController(
            ICreateOrder createOrder,
            IGetOrder getOrder)
        {
            _createOrder = createOrder;
            _getOrder = getOrder;
        }

        //  Create Order
        [HttpPost]
        public async Task<IActionResult> Create(OrederRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _createOrder.CreateOrderAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        //  Get Order By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _getOrder.GetOrderByIdAsync(id);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }
    }
}