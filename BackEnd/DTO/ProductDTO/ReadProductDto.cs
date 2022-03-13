using BackEnd.DTO.CategoryDTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.DTO.ProductDTO
{
    public class ReadProductDto : BaseDTO
    {
        public string Name { get; set; }

        public string description { get; set; }

        public int cost { get; set; }

        public int Quantity { get; set; }

        public bool stopped { get; set; }

        public Guid ? CategoryId { get; set; }

        public string Pic1 { get; set; }

        public string Pic2 { get; set; }

        public string Pic3 { get; set; }

        public string Pic4 { get; set; }

        public bool IsPublished { get; set; }
    }
}
