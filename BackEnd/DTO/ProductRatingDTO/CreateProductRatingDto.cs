using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO.ProductRatingDTO
{
    public class CreateProductRatingDto
    {
        [StringLength(3000)]
        public string Comment { get; set; }
        [Range(0, 5)]
        public float Rating { get; set; } = 5;

        public Guid ProductId { get; set; }

        public Guid OrderItemId { get; set; }

        public bool IsRated { get; set; } = false;
    }
}
