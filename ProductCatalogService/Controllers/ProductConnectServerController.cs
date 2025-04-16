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
        [Route("Products")]
        public async Task<IActionResult> Index()
        {
            var products = await _productsService.GetAsync();
            return View("Index", products);
        }

        [HttpGet]
        [Route("Products/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var product = await _productsService.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View("Details", product);
        }

        [HttpGet]
        [Route("Products/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Products/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Products product)
        {
            if (ModelState.IsValid)
            {
                await _productsService.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        [Route("Products/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var product = await _productsService.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View("Edit", product);
        }

        [HttpPost]
        [Route("Products/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Products product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _productsService.UpdateAsync(id, product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        [Route("Products/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productsService.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View("Delete", product);
        }

        [HttpPost]
        [Route("Products/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _productsService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // API Endpoints
        [ApiController]
        [Route("api/[controller]")]
        public class ProductsApiController : ControllerBase
        {
            private readonly ProductsService _productsService;

            public ProductsApiController(ProductsService productsService)
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
}
