using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        Contex contex;
        public LoginController()
        {

            contex = new Contex();

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Admin admin)
        {  
            var cx =  contex.admins.ToList();
            for (int i = 0; i < cx.Count; i++)
            {
                if (cx[i].AdminName.Equals(admin.AdminName))
                {
                    return RedirectToAction( "Index", "Home");
                }
            }


            return View();
        }
    }
}
