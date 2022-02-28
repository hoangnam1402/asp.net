using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return Ok(await _context.categories.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category category)
        {
            _context.categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(await _context.categories.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(Guid id)
        {
            var category = await _context.categories.FindAsync(id);
            if (category == null)
                return BadRequest("Category not found.");

            _context.categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok(await _context.categories.ToListAsync());
            return Ok(await _context.categories.ToListAsync());
        }
    }
}