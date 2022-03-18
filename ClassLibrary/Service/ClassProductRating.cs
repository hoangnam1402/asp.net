using AutoMapper;
using BackEnd.Data;
using BackEnd.DTO.ProductRatingDTO;
using BackEnd.Model;
using ClassLibrary.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Service
{
    public class ClassProductRating : IProductRatingClass
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClassProductRating(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadProductRatingDto> AddRatingAsync(CreateProductRatingDto createProductRatingDto)
        {
            ProductRating productRating = _mapper.Map<ProductRating>(createProductRatingDto);
            _context.productsRating.Add(productRating);
            await _context.SaveChangesAsync();
            return _mapper.Map<ReadProductRatingDto>(productRating);
        }

        public async Task<List<ReadProductRatingDto>> GetListProductRatingByProductIdAsync(Guid productId)
        {
            var query = await _context.productsRating.Where(x => x.OrderItemId == productId).ToListAsync();
            var responce = _mapper.Map<List<ReadProductRatingDto>>(query);

            return responce;
        }

        public async Task<ReadProductRatingDto> GetProductRatingAsync(Guid id)
        {
            var query = await _context.productsRating.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (query == null)
                return null;

            var response = _mapper.Map<ReadProductRatingDto>(query);
            return response;
        }

        public async Task RatingAsync(UpdateProductRatingDto updateProductRatingDto)
        {
            var productRating = _mapper.Map<ProductRating>(updateProductRatingDto);
            _context.productsRating.Update(productRating);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRatingAsync(Guid id)
        {
            var productRating = await _context.productsRating.FirstOrDefaultAsync(x => x.Id == id);
            _context.productsRating.Remove(productRating);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ReadProductRatingDto>> AddRangeProductRatingAsync(List<CreateProductRatingDto> createProductRatingDtos)
        {
            var orderItems = _mapper.Map<List<OrderItem>>(createProductRatingDtos);
            _context.AddRangeAsync(orderItems);
            await _context.SaveChangesAsync();
            return _mapper.Map<List<ReadProductRatingDto>>(orderItems);
        }
    }
}
