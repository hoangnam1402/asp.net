using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _context.products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductInfo(string id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
                return BadRequest("Product not found.");
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.products.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct(Product UpdataProduct)
        {
            var product = await _context.products.FindAsync(UpdataProduct.Id);
            if (product == null)
                return BadRequest("Product not found.");

            product.name = UpdataProduct.name;
            product.description = UpdataProduct.description;
            product.cost = UpdataProduct.cost;
            product.inventory = UpdataProduct.inventory;
            product.stopped = UpdataProduct.stopped;

            await _context.SaveChangesAsync();

            return Ok(await _context.products.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(string id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
                return BadRequest("Product not found.");

            _context.products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.products.ToListAsync());
        }
    }
}