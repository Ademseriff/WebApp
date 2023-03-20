using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly ILogger<HomeController> _logger;

        Contex contex;
        public HomeController(ILogger<HomeController> logger)
        {
             contex = new Contex();
            _logger = logger;
        }
        //burası ana sayfa burda adminleri listeleme yaptım.
        public IActionResult Index()
        {

           var cx= contex.admins.ToList();
            return View(cx);
        }
        [HttpGet]
        public IActionResult AdminEkle()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AdminEkle(Admin admin)
        {
            
            contex.admins.Add(admin);
            contex.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
