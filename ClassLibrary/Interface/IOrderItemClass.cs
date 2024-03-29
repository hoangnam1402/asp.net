﻿using BackEnd.DTO.OrderDTO;
using BackEnd.DTO.ProductRatingDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface IOrderItemClass
    {
        Task<ReadOrderItemDto> AddOrderItemAsync(CreateOrderItemDto createOrderItemDto);

        Task<List<ReadOrderItemDto>> GetOrderByOrderIdAsync(Guid id);

        Task<List<ReadOrderItemDto>> AddRangeOrderItemsAsync(List<CreateOrderItemDto> createOrderItemDtos);

        Task<List<ReadProductRatingDto>> GetListProductRatingByProductIdAsync(Guid productId);
    }
}
