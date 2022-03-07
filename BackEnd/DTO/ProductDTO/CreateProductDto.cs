using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.DTO.ProductDTO
{
    public class CreateProductDto
    {
        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        public int cost { get; set; }

        public int inventory { get; set; }

        public bool stopped { get; set; }

        public Guid? CategoryId { get; set; }

        public CategoryDto? Category { get; set; }
    }
}
