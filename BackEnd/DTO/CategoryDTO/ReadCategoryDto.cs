using BackEnd.DTO.ProductDTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.DTO.CategoryDTO
{
    public class ReadCategoryDto : BaseDTO
    {
        public string CategoryName { get; set; }

        public string? Content { set; get; }

    }
}
