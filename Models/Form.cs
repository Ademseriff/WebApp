﻿using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]

        public string Message { get; set; }
    }
}
