using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AnaSayfaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
