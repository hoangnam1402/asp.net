using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BackEnd.DTO.ProductDTO;
using EnsureThat;

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
        public async Task<ActionResult<List<ReadProductDto>>> GetAllProduct()
        {
            if  (_context.products == null)
            {
                return NotFound();
            }

            //var pageResults = 3f;
            //var pageCount = Math.Ceiling(_context.products.Count() / pageResults);

            //var product = await _context.products
            //    .Skip((page - 1) * (int)pageResults)
            //    .Take((int)pageResults)
            //    .ToListAsync();
            var product = await _context.products.ToListAsync();
            
            var productDtoResponse = _mapper.Map<List<ReadProductDto>>(product);

            //var response = new ProductResponseDto
            //{
            //    Products = productDtoResponse,
            //    CurrentPages = page,
            //    Pages = (int)pageCount
            //};

            return Ok(productDtoResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadProductDto>> GetProduct(Guid id)
        {
            var product = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return BadRequest("Product not found.");

            var response = _mapper.Map<ReadProductDto>(product);
            return Ok(response);
        }

        [HttpGet("/api/Product/Search")]
        public async Task<ActionResult<List<ReadProductDto>>> SearchProduct(int page,string keywork)
        {
            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.products.Where(x => x.Name.Contains(keywork)).Count() / pageResults);

            var product = await _context.products
                .Where(x => x.stopped == true)
                .Where(x => x.Name.Contains(keywork))
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var productDtoResponse = _mapper.Map<List<ReadProductDto>>(product);

            var response = new ProductResponseDto
            {
                Products = productDtoResponse,
                CurrentPages = page,
                Pages = (int)pageCount
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<CreateProductDto>>> AddProduct(CreateProductDto newProduct)
        {
            Ensure.Any.IsNotNull(newProduct, nameof(newProduct));
            var product = _mapper.Map<Product>(newProduct);

            _context.products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateProductDto>> UpdateProduct(UpdateProductDto UpdataProduct)
        {
            Ensure.Any.IsNotNull(UpdataProduct, nameof(UpdataProduct));
            var product = _mapper.Map<Product>(UpdataProduct);
            
            _context.products.Update(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.products.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var product = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return BadRequest("Product not found.");

            _context.products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.products.ToListAsync());
        }
    }
}