using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AnaSayfaFormController : Controller
    {
        Contex contex;
        public AnaSayfaFormController() {
        
        contex = new Contex();
        
        }
        
        [HttpPost]
        public IActionResult Index(Form form)
        {
            
            contex.forms.Add(form);
            contex.SaveChanges();
            return RedirectToAction("Index", "AnaSayfa");
        }

        [HttpGet]
        public IActionResult FormGet()
        {
           var cx= contex.forms.ToList();
            return View(cx);
        }
    }
}
