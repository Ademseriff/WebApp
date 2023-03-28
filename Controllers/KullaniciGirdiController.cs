using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class KullaniciGirdiController : Controller
    {
        Contex contex;
        public static int değer ;

        public KullaniciGirdiController()
        {
           
            contex = new Contex();


           
        }
        [HttpGet]
        public IActionResult Index(User user)
        {

            TempData["KulaniciAd"]  = user.KullaniciAd;
            TempData["Sifre"] = user.KullaniciSifre;
            TempData["KulaniciPara"] = user.KullaniciPara;
            TempData["KulaniciTc"] = user.KullaniciTc;
            TempData["KulaniciSoyad"] = user.KullaniciSoyad;
            TempData["KulaniciIl"] = user.KullaniciIl;
            TempData["KulaniciId"] = user.KullaniciId;
            değer = 1;
            
            return View(user);
        }

    }
}
