using BackEnd.DTO.CategoryDTO;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO.ProductDTO
{
    public class ListProductDto
    {
        [StringLength(50)]
        public string name { get; set; }

        public int cost { get; set; }

        public Guid? CategoryId { get; set; }

        public CategoryDto? Categories { get; set; }
    }
}
