using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SatinAlmaController : Controller
    {
        Contex contex;
        Arac arac;
        public SatinAlmaController()
        {

            contex = new Contex();
            arac = new Arac();

        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            arac = contex.aracs.Find(id);
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            var cx = contex.users.ToList();
            for (int i = 0; i < cx.Count; i++)
            {
                if (cx[i].KullaniciAd.Equals(user.KullaniciAd))
                {
                   int KullaniciPara = Convert.ToInt32(cx[i].KullaniciPara);
                   int AracPara = Convert.ToInt32(arac.AracFiyat);
                    if (KullaniciPara > AracPara)
                    {
                        return RedirectToAction("Index", "AnaSayfa");
                    }

                    return View();
                }
            }
            return View();
        }
    }
}
