using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SatinAlmaController : Controller
    {
        Contex contex;
        Arac arac;
        AracAlindi aracAlindi;
        public static int aracId;
        public SatinAlmaController()
        {

            contex = new Contex();
            arac = new Arac();
            aracAlindi = new AracAlindi();


        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            arac = contex.aracs.Find(id);
            aracId = arac.AracId;
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            var cx = contex.users.ToList();
            for (int i = 0; i < cx.Count; i++)
            {
                if (cx[i].KullaniciAd.Equals(user.KullaniciAd) && cx[i].KullaniciSifre.Equals(user.KullaniciSifre))
                {
                    user.KullaniciSoyad = cx[i].KullaniciSoyad;
                    user.KullaniciTc = cx[i].KullaniciTc;
                    user.KullaniciIl = cx[i].KullaniciIl;
                    int KullaniciPara = Convert.ToInt32(cx[i].KullaniciPara);
                    arac = contex.aracs.Find(aracId);
                   
                    int AracPara = Convert.ToInt32(arac.AracFiyat);
                    if (KullaniciPara > AracPara)
                    {
                        int KalanPara = KullaniciPara - AracPara;
                        user.KullaniciPara = KalanPara.ToString();
                        aracAlindi.AracMarka= arac.AracMarka;
                        aracAlindi.AracModel = arac.AracModel;
                        aracAlindi.KullaniciAd=user.KullaniciAd;
                        aracAlindi.KullaniciSifre= user.KullaniciSifre;
                        contex.AracAlindis.Add(aracAlindi);
                        contex.users.Update(user);
                        contex.aracs.Remove(arac);
                        contex.users.Remove(cx[i]);
                        contex.SaveChanges();
                        return RedirectToAction("Index", "ThankYou");
                    }
                    else if(KullaniciPara < AracPara)
                    {
                        
                        return RedirectToAction("Index", "Eror");
                    }

                 //   return View();
                }
            }
            return View();
        }
    }
}
