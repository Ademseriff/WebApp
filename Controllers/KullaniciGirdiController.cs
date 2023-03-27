using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class KullaniciGirdiController : Controller
    {
        public IActionResult Index(User user)
        {
            TempData["KulaniciAd"]  = user.KullaniciAd;
            TempData["Sifre"] = user.KullaniciSifre;
            
            return View(user);
        }
    }
}
