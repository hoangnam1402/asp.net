using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO.CustomerDTO
{
    public class UpdateCustomerDto
    {
        [StringLength(50)]
        public string name { get; set; }

        public string Address { get; set; }

        public string PhoneNumer { get; set; }
    }
}
