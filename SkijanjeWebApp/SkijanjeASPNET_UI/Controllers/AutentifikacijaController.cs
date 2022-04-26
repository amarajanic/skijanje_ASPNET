using Microsoft.AspNetCore.Mvc;
using SkijanjeASPNET.Models;
using SkijanjeLibrary.Models;
using SkijanjeLibrary.Services;
using SkijanjeLibrary.Helper;

namespace SkijanjeASPNET.Controllers
{
    public class AutentifikacijaController : Controller
    {
        AutentifikacijaService autentifikacijaService = new AutentifikacijaService();

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(AutentifikacijaVM x)
        {
            KorisnickiNalog nalog = await  autentifikacijaService.ProvjeriLogin(x.Username, x.Password);
            if (nalog == null)
            {
                TempData["porukaGreska"] = "Neispravan username/password...";
                return Redirect("/Autentifikacija/Index");
            }

            Autentifikacija.SetLogiraniKorisnik(HttpContext, nalog);

            return Redirect("/");
        }

        public IActionResult Logout()
        {
            Autentifikacija.SetLogiraniKorisnik(HttpContext, null);
            return Redirect("/");
        }

    }
}
