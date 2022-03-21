using AutoMapper;
using BackEnd.Data;
using BackEnd.DTO.OrderDTO;
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
    public class ClassOrder : IOrderClass
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClassOrder(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReadOrderDto> CreateOrder(CreateOrderDto createOrderDto)
        {
            if (createOrderDto == null)
                throw new ArgumentNullException(nameof(createOrderDto));
            Order order = _mapper.Map<Order>(createOrderDto);
            _context.orders.Add(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReadOrderDto>(order);
        }

        public async Task<ReadOrderDto> GetOrderByIdAsync(Guid id)
        {
            var query = await _context.orders.FirstOrDefaultAsync(x => x.Id == id);

            if (query == null)
                return null;

            var response = _mapper.Map<ReadOrderDto>(query);
            return response;
        }
    }
}

