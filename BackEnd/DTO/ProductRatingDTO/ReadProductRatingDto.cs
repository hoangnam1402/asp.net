using BackEnd.DTO.OrderDTO;

namespace BackEnd.DTO.ProductRatingDTO
{
    public class ReadProductRatingDto : BaseDTO
    {
        public string Comment { get; set; }

        public float Rating { get; set; }

        public Guid ProductId { get; set; }

        public bool IsRated { get; set; }

        public Guid OrderItemId { get; set; }
        public ReadOrderItemDto OrderItem { get; set; }
    }
}
