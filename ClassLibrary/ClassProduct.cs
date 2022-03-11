using BackEnd.Model;
using BackEnd.Data;
using BackEnd.DTO.ProductDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class ClassProduct : IProductClass
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClassProduct(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReadProductDto>> GetProduct()
        {
            var product = await _context.products.Where(x => x.stopped == false).ToListAsync();

            if (product == null)
            {
                return null;
            }

            var response = _mapper.Map<List<ReadProductDto>>(product);

            return response;
        }

        public async Task<ReadProductDto> GetProductDetail(Guid id)
        {
            var product = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return null;
            }

            var response = _mapper.Map<ReadProductDto>(product);
            return response;
        }
    }
}