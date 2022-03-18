using BackEnd.Model;
using BackEnd.Data;
using BackEnd.DTO.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Interface;
using AutoMapper;
using BackEnd.Interface;

namespace ClassLibrary.Service
{
    public class ClassProduct : IProductClass
    {
        private readonly IBaseRepository<Product> _baseRepository;
        private readonly IMapper _mapper;
        public ClassProduct(IBaseRepository<Product> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<List<ReadProductDto>> GetAsync()
        {
            var product = _context.products.Where(x => x.stopped == false).ToList();
            //var product = _context.products.ToList();

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public Product GetProductDetail(Guid id)
        {
            var product = _context.products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return null;
            }

            return product;
        }
    }
}