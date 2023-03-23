using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ThankYouController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
