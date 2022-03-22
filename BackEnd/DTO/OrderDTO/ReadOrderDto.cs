using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO.OrderDTO
{
    public class ReadOrderDto : BaseDTO
    {
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string ? Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public List<ReadOrderItemDto> OrderItems { get; set; }
    }
}
