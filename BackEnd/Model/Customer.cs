using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Model
{
    public class Customer
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public string Address { get; set; }

        public string PhoneNumer { get; set; }

        public DateTime SignDay { get; set; } = DateTime.Now;
    }
}
