using Microsoft.AspNetCore.Mvc;
using SkijanjeASPNET.Controllers;
using SkijanjeASPNET_UI.Models;
using SkijanjeLibrary.Helper;
using System.Diagnostics;

namespace SkijanjeASPNET_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //if (Autentifikacija.GetLogiraniKorisnik(HttpContext) == null)
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");
            return View("Index");
        }

        public IActionResult Privacy()
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}