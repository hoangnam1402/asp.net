using AutoMapper;
using BackEnd.Data;
using BackEnd.DTO.OrderDTO;
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
    public class ClassOrderItem : IOrderItemClass
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ClassOrderItem(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReadOrderItemDto> AddOrderItemAsync(CreateOrderItemDto createOrderItemDto)
        {
            if (createOrderItemDto == null)
                throw new ArgumentNullException(nameof(createOrderItemDto));
            OrderItem orderItem = _mapper.Map<OrderItem>(createOrderItemDto);
            _context.orderItems.Add(orderItem);
            await _context.SaveChangesAsync();
            return _mapper.Map<ReadOrderItemDto>(orderItem);
        }

        public async Task<List<ReadProductRatingDto>> GetListProductRatingByProductIdAsync(Guid productId)
        {
            var query = await _context.orderItems.ToListAsync();
            var tmp = query.Where(x => x.ProductId == productId).AsQueryable()
                .Include(o => o.ProductRating);
            return _mapper.Map<List<ReadProductRatingDto>>(await tmp.Select(x => x.ProductRating).ToListAsync());
        }

        public async Task<List<ReadOrderItemDto>> GetOrderByOrderIdAsync(Guid id)
        {
            var query = await _context.orderItems.Where(x => x.OrderId == id).ToListAsync();
            return _mapper.Map<List<ReadOrderItemDto>>(query);
        }

        public async Task<List<ReadOrderItemDto>> AddRangeOrderItemsAsync(List<CreateOrderItemDto> createOrderItemDtos)
        {
            var orderItems = _mapper.Map<List<OrderItem>>(createOrderItemDtos);
            _context.AddRangeAsync(orderItems);
            await _context.SaveChangesAsync();
            return _mapper.Map<List<ReadOrderItemDto>>(orderItems);
        }
    }
}