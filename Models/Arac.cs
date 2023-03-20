using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Arac
    {
        [Key]
        public int AracId { get; set; }
        [Required]

        public string AracMarka { get; set;}
        [Required]
        public string AracModel { get; set; }
        [Required]
        public string AracFiyat { get; set; }
    }
}
