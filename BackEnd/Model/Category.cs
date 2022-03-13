using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Model
{
    public class Category : BaseEntity
    {
        public string CategoryName { set; get; }

        [StringLength(maximumLength: 100)]
        public string ? Content { set; get; }

        public List<Product> Products { get; set; }
    }
}
