using Microsoft.AspNetCore.Mvc;
using mini_ecommerce_backend.Domain.DTOs.Request;
using mini_ecommerce_backend.Domain.Interfaces;

namespace mini_ecommerce_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICreateProduct _createProduct;
        private readonly IListProducts1 _listProducts;

        public ProductsController(
            ICreateProduct createProduct,
            IListProducts1 listProducts)
        {
            _createProduct = createProduct;
            _listProducts = listProducts;
        }

        //  Create Product
        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _createProduct.CreateProductAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        //  Get All Products (Paginated)
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginatedRequest request)
        {
            var result = await _listProducts.GetAllProductsAsync(request);
            return Ok(result);
        }
    }
}