using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class KullaniciGirdiController : Controller
    {
        public IActionResult Index(User user)
        {
            return View(user);
        }
    }
}
