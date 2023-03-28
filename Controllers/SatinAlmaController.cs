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
            // TempData["KulaniciAd"] != null && TempData["Sifre"] != null
            //ViewBag.Adin != null
            
            if (KullaniciGirdiController.değer == 1)
            {
                int kullaniciPara = Convert.ToInt32(TempData["KulaniciPara"]);
                int aracFiyat = Convert.ToInt32(arac.AracFiyat);
                if (kullaniciPara > aracFiyat)
                {
                    User user = new User();
                    User user2 = new User();
                    int KalanPara = kullaniciPara - aracFiyat;
                    user.KullaniciPara= KalanPara.ToString();
                    user.KullaniciSoyad = (string)TempData["KulaniciSoyad"];
                    user.KullaniciTc = (string)TempData["KulaniciTc"];
                    user.KullaniciIl = (string)TempData["KulaniciIl"];
                    user.KullaniciAd = (string)TempData["KulaniciAd"];
                    user.KullaniciSifre = (string)TempData["Sifre"];

                    user2.KullaniciPara = KalanPara.ToString();
                    user2.KullaniciSoyad = (string)TempData["KulaniciSoyad"];
                    user2.KullaniciTc = (string)TempData["KulaniciTc"];
                    user2.KullaniciIl = (string)TempData["KulaniciIl"];
                    user2.KullaniciAd = (string)TempData["KulaniciAd"];
                    user2.KullaniciSifre = (string)TempData["Sifre"];
                    user2.KullaniciId = (int)TempData["KulaniciId"];



                  
                    aracAlindi.AracMarka = arac.AracMarka;
                    aracAlindi.AracModel = arac.AracModel;
                    aracAlindi.KullaniciAd = (string)TempData["KulaniciAd"];
                    aracAlindi.KullaniciSifre = (string)TempData["Sifre"];
                    contex.AracAlindis.Add(aracAlindi);

                    contex.users.Update(user);
                    contex.aracs.Remove(arac);
                    KullaniciGirdiController.değer = 0;
                    contex.users.Remove(user2);
                    contex.SaveChanges();
                    return RedirectToAction("Index", "ThankYou");

                }

              


            }
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
