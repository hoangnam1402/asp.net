using BackEnd.DTO.CategoryDTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.DTO.ProductDTO
{
    public class ReadProductDto
    {
        public Guid Id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int cost { get; set; }

        public int inventory { get; set; }

        public Guid ? CategoryId { get; set; }

        public int ? rating { get; set; }

        public string img { get; set; }

        public DateTime CreateDay { get; set; }

        public DateTime ? UpdateDay { get; set; }
    }
}
