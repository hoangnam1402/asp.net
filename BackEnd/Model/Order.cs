using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Model
{
    public class Order : BaseEntity
    {
        public string Status { get; set; }

        public int TotalPrice { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public string ? Address { get; set; }

        public string Note { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
