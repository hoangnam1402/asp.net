using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Model
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public string Address { get; set; }

        public string PhoneNumer { get; set; }

        public DateTime SignDay { get; set; }
    }
}
