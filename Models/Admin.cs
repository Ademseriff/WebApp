using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Admin
    {

        [Key]
        public int AdminId { get; set; }

        [Required]
        public string AdminName { get; set; }

        [Required]
        public string AdminSifre { get; set; }

    }
}
