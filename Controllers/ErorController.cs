using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ErorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
