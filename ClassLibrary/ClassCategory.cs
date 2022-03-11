using BackEnd.Data;
using BackEnd.DTO.CategoryDTO;
using BackEnd.DTO.ProductDTO;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class ClassCategory : ICategoryClass
    {
        private readonly ApplicationDbContext _context;

        public ClassCategory(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            var category = _context.categories.ToList();
            if (category == null)
                return null;

            return category;
        }
    }
}
