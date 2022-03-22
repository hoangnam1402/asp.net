using BackEnd.DTO.CategoryDTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.DTO.ProductDTO
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        public int cost { get; set; }

        public int Quantity { get; set; }

        public bool stopped { get; set; }

        public Guid? CategoryId { get; set; }

        public bool IsFeatured { get; set; }

        public DateTime UpdateDay { get; set; }

        public string Pic1 { get; set; }

        public string Pic2 { get; set; }

        public string Pic3 { get; set; }

        public string Pic4 { get; set; }
    }
}
