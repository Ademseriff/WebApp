using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp.Models;


namespace WebApp.Controllers
{
    public class AnaSayfaController : Controller
    {
        Contex contex;
        public AnaSayfaController()
        {
            contex = new Contex();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Arac arac)
        {
            var cx = contex.aracs.ToList();

            for (int i = 0; i < cx.Count; i++)
            {
                if (cx[i].AracMarka.Equals(arac.AracMarka))
                {
                    ViewBag.AracMarka = arac.AracMarka;

                    return View("AracListele", cx);
                }

            }
            return View();
        }




    }
}
