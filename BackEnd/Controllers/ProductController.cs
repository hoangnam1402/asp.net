using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BackEnd.DTO.ProductDTO;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReadProductDto>>> Get(int page)
        {
            if  (_context.products == null)
            {
                return NotFound();
            }

            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.products.Count() / pageResults);

            var productResponse = await _context.products
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var productDtoResponse = _mapper.Map<List<ReadProductDto>>(productResponse);

            var response = new ProductResponseDto
            {
                Products = productDtoResponse,
                CurrentPages = page,
                Pages = (int)pageCount
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductInfo(Guid id)
        {
            var product = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
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
        public async Task<ActionResult<Product>> DeleteProduct(Guid id)
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