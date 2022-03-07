using BackEnd.DTO.ProductDTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.DTO.CategoryDTO
{
    public class ReadCategoryDto
    {
        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string? Content { set; get; }

    }
}
