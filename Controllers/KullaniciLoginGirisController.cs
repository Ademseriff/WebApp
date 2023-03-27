using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class KullaniciLoginGirisController : Controller
    {
        Contex contex;

        public KullaniciLoginGirisController() { 
        
        contex = new Contex();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
           var cx = contex.users.ToList();

            for (int i = 0;i<cx.Count;i++)
            {
                if (cx[i].KullaniciAd.Equals(user.KullaniciAd) && cx[i].KullaniciSifre.Equals(user.KullaniciSifre))
                {
                    return RedirectToAction("Index", "KullaniciGirdi", cx[i]);
                }



            }

            return View();
        }


    }
}
