using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO.ProductRatingDTO
{
    public class UpdateProductRatingDto
    {
        public Guid Id { get; set; }

        [StringLength(3000)]
        public string Comment { get; set; }
        [Range(0, 5)]
        public float Rating { get; set; } = 5;

        public bool IsRated { get; set; } = true;

        public DateTime UpdatedDate { get; set; }
    }
}
