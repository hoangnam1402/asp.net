using BackEnd.DTO.ProductRatingDTO;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface IProductRatingClass
    {
        Task<ReadProductRatingDto> AddRatingAsync(CreateProductRatingDto createProductRatingDto);

        Task RatingAsync(UpdateProductRatingDto updateProductRatingDto);

        Task RemoveRatingAsync(Guid id);

        Task<ReadProductRatingDto> GetProductRatingAsync(Guid id);

        Task<List<ReadProductRatingDto>> GetListProductRatingByProductIdAsync(Guid productId);

        Task<List<ReadProductRatingDto>> AddRangeProductRatingAsync(List<CreateProductRatingDto> createProductRatingDtos);
    }
}
