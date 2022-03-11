using BackEnd.Model;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO.ProductDTO
{
    public class ProductCartDto
    {
        public Product Product { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The Quantity should be greater than 1")]
        public int Quantity { get; set; }
    }
}
