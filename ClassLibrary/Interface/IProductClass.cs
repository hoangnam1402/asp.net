using BackEnd.DTO.ProductDTO;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface IProductClass
    {
        Task<IEnumerable<ReadProductDto>> GetAllAsync();

        Task<PagedResponseModel<ReadProductDto>> PagedQueryAsync(string name, Guid? categoryId, int? page, int limit);

        Task<ReadProductDto> GetByIdAsync(Guid id);

        Task<ReadProductDto> GetByNameAsync(string name);

        Task<ReadProductDto> AddAsync(CreateProductDto ProductDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(UpdateProductDto ProductDto);
        Task SoftDeleteAsync(Guid id);

        Task<List<ReadProductDto>> GetRelatedProducts(Guid categroyId, int num);

        Task<List<ReadProductDto>> FilterProducts(bool isLastest, bool isFeatured, int num);
    }
}
