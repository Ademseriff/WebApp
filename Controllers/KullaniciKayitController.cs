using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class KullaniciKayitController : Controller
    {
        Contex contex;

        public KullaniciKayitController()
        {
            contex=new Contex();
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            contex.users.Add(user);
            contex.SaveChanges();
            return RedirectToAction("Index","AnaSayfa");
        }
        [HttpGet]
        public IActionResult Kullanici()
        {
            var cx=contex.users.ToList();
            return View(cx);
        }

    }
}
