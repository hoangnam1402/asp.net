using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO.CustomerDTO
{
    public class CreateCustomerDto
    {
        [StringLength(50)]
        public string name { get; set; }

        public string Address { get; set; }

        public string PhoneNumer { get; set; }

        public DateTime SignDay { get; set; } = DateTime.Now;
    }
}
