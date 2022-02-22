using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Model
{
    public class Category
    {
        [Key]
        [StringLength(20)]
        public string CategoryId { set; get; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }
    }
}
