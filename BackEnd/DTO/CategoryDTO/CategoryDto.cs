using BackEnd.DTO.ProductDTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.DTO.CategoryDTO
{
    public class CategoryDto
    {
        [Column(TypeName = "ntext")]
        public string? Content { set; get; }

        public List<CreateProductDto>? Products { get; set; }
    }
}
