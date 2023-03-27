using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class KullaniciAracListeleController : Controller
    {
        Contex contex;
        public KullaniciAracListeleController()
        {
            contex = new Contex();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var cx = contex.AracAlindis.ToList();
            return View(cx);
        }
    }
}
