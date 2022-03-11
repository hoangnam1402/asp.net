using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Model
{
    public class Customer : IdentityUser
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime SignDay { get; set; }
    }
}
