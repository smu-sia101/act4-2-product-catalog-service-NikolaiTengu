using Microsoft.AspNetCore.Mvc;
using ProductCatalogService.Services;
using ProductCatalogService.ProductsModels;

namespace ProductCatalogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductConnectServerController : Controller
    {
        private readonly ProductsService _productsService;

        public ProductConnectServerController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<List<Products>> Get() =>
        await _productsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Products>> Get(string id)
        {
            var product = await _productsService.GetAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Products newProducts)
        {
            await _productsService.CreateAsync(newProducts);

            return CreatedAtAction(nameof(Get), new { id = newProducts.Id }, newProducts);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Products updatedProducts)
        {
            var product = await _productsService.GetAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            updatedProducts.Id = product.Id;

            await _productsService.UpdateAsync(id, updatedProducts);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productsService.GetAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            await _productsService.RemoveAsync(id);

            return NoContent();
        }

    }
}
