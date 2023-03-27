using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class AracAlindi
    {
        [Key] 
        public int AracAlindiId { get; set; }

        [Required]

        public string KullaniciAd { get; set; }

        [Required]

        public string KullaniciSifre { get; set; }


        [Required]
        public string AracMarka { get; set; }

        [Required]

        public string AracModel { get; set; }
    }
}
