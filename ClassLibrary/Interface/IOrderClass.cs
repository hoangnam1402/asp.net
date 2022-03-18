using BackEnd.DTO.OrderDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface IOrderClass
    {
        Task<ReadOrderDto> CreateOrder(CreateOrderDto createOrderDto);
        Task<List<ReadOrderDto>> GetListOrderByUserIdAsync(string userId);

        Task<ReadOrderDto> GetOrderByIdAysnc(Guid id);

        Task<int> GetTotalOrderByUserId(string userId);
    }
}
