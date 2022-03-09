using BackEnd.DTO.CategoryDTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.DTO.ProductDTO
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        public int cost { get; set; }

        public int inventory { get; set; }

        public bool stopped { get; set; }

        public Guid? CategoryId { get; set; }

        public int ? rating { get; set; }

        public string img { get; set; }
    }
}
