using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO
{
    public class BaseDTO
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
