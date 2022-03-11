using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO.CustomerDTO
{
    public class UpdateCustomerDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string name { get; set; }

        [Required(ErrorMessage = "Passwork Name is required")]
        public string Passwork { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "The Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage = "Address Name is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "PhoneNumer Name is required")]
        public string PhoneNumber { get; set; }
    }
}
