using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Model
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            UpdatedDate = DateTime.Now;
            CreatedDate = DateTime.Now;
        }
        [Key]
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
    }
}
