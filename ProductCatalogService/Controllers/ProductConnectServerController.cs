using Microsoft.AspNetCore.Mvc;
using ProductCatalogService.Services;

namespace ProductCatalogService.Controllers
{
    [ApiController]
    [Route("[Controller")]
    public class ProductConnectServerController : Controller
    {
        private readonly ProductsService _productsService;

        public ProductConnectServerController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("/api/products")]
        public IActionResult GetAllProducts()
        {
            return Ok();
        }

        [HttpGet("/api/products/{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok();
        }

        [HttpPost("/api/products")]
        public IActionResult AddProduct()
        {
            return Ok();
        }

        [HttpPut("/api/products/{id}")]
        public IActionResult UpdateProduct(int id)
        {
            return Ok();
        }

        [HttpDelete("/api/products/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok();
        }
    }

}
