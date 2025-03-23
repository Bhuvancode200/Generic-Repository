using Generic_Repository.Entity;
using Generic_Repository.Repository;
using Generic_Repository.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Generic_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithGenericRepoController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;

        public ProductWithGenericRepoController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductRequest product)
        {
            var productEntity = new Product
            {
                Name = product.ProductName,
                Price = product.Price
            };

            var createdProduct = await _productRepository.AddAsync(productEntity);
            return CreatedAtAction(nameof(Get), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductRequest product)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            if (productEntity == null)
                return NotFound();

            if (id != productEntity.Id)
                return BadRequest("ID in URL does not match the product ID.");

            productEntity.Name = product.ProductName;
            productEntity.Price = product.Price;

            await _productRepository.UpdateAsync(productEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                    return NotFound();

                await _productRepository.DeleteAsync(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting product: {ex.Message}");
            }
        }
    }
}
