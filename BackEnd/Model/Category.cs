﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Model
{
    public class Category
    {
        [Key]
        public Guid CategoryId { set; get; }

        [Column(TypeName = "ntext")]
        public string ? Content { set; get; }

        public List<Product> ? Products { get; set; }
    }
}
