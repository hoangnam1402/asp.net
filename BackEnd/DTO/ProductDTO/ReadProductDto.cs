using BackEnd.DTO.CategoryDTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.DTO.ProductDTO
{
    public class ReadProductDto
    {
        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        public int cost { get; set; }

        public int inventory { get; set; }

        public Guid ? CategoryId { get; set; }

        public CategoryDto ? Categories { get; set; }
    }
}
