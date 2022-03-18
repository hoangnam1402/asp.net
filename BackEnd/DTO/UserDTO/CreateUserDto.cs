using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO.CustomerDTO
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Passwork Name is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "The Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Address Name is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "PhoneNumer Name is required")]
        public string PhoneNumber { get; set; }
    }
}
