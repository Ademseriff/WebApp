using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class User
    {
        [Key]
        public int KullaniciId { get; set; }
        [Required]
        public string KullaniciAd { get; set; }
        [Required]
        public string KullaniciSoyad { get; set; }
        [Required]
        public string KullaniciTc { get; set; }
        [Required]
        public string KullaniciIl { get; set; }

        public string KullaniciPara { get; set; }
    }
}
