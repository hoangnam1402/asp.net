﻿using IdentityServer4.Models;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO.OrderDTO
{
    public class CreateOrderDto
    {
        public string Status { get; set; } = "success";

        public int TotalPrice { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
