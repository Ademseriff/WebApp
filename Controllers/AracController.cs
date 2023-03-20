using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AracController : Controller
    {
        Contex contex;
        public AracController() {

            contex = new Contex();

        }
        public IActionResult Index()
        {
            var cx = contex.aracs.ToList();
            return View(cx);
           
        }
        [HttpGet]
        public IActionResult AracEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AracEkle(Arac arac)
        {
            contex.aracs.Add(arac);
            contex.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
