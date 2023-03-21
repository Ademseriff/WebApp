using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AnaSayfaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
