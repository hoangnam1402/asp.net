using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BackEnd.DTO.CategoryDTO;
using EnsureThat;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReadCategoryDto>>> Get()
        {
            var category = await _context.categories.ToListAsync();
            if (category == null)
                return BadRequest("Category not found.");

            var response = _mapper.Map<List<ReadCategoryDto>>(category);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<CreateCategoryDto>>> AddCategory(CreateCategoryDto newCategory)
        {
            Ensure.Any.IsNotNull(newCategory, nameof(newCategory));
            var category = _mapper.Map<Category>(newCategory);

            _context.categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var category = await _context.categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (category == null)
                return BadRequest("Category not found.");

            _context.categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok(await _context.categories.ToListAsync());
        }
    }
}