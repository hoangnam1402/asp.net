using BackEnd.DTO.ProductDTO;
using BackEnd.DTO.ProductRatingDTO;

namespace BackEnd.DTO.OrderDTO
{
    public class ReadOrderItemDto :BaseDTO
    {
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public ReadProductDto Product { get; set; }
        public ReadProductRatingDto ProductRating { get; set; }
    }
}
