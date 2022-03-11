using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Model
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        public int cost { get; set; }

        public bool stopped { get; set; }

        public Guid ? CategoryId { get; set; } 

        public Category ? Category { get; set; }

        public int ? rating { get; set; }

        public string img { get; set; }

        public DateTime CreateDay { get; set; }

        public DateTime ? UpdateDay { get; set; }

        public bool IsFeatured { get; set; }
    }
}
