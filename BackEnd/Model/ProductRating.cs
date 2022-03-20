using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Model
{
    public class ProductRating : BaseEntity
    {
        [StringLength(3000)]
        public string Comment { get; set; }
        [Range(0, 5)]
        public int Rating { get; set; } = 5;

        public Guid OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; }

        public bool IsRated { get; set; } = false;
    }
}
