using AutoMapper;
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
        private readonly IMapper _mapper;

        public ClassCategory(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReadCategoryDto>> GetCategories()
        {
            var category = await _context.categories.ToListAsync();
            if (category == null)
                return null;

            var response = _mapper.Map<List<ReadCategoryDto>>(category);
            return response;
        }
    }
}
