using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Model
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
    }
}
