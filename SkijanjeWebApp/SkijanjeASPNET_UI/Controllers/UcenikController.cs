using Microsoft.AspNetCore.Mvc;
using SkijanjeASPNET.Models;
using SkijanjeLibrary.Helper;
using SkijanjeLibrary.Models;
using SkijanjeLibrary.Services;

namespace SkijanjeASPNET.Controllers
{
    public class UcenikController : Controller
    {
        UcenikService ucenikService = new UcenikService();
        public async Task<IActionResult> Prikaz()
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            var ucenici = await ucenikService.GetAll();

            var uceniciVM = ucenici.Select(x => new UcenikPrikazVM
            {
                Ime = x.Ime,
                Prezime = x.Prezime,
                DatRodj = x.DatRodj,
                Spol = x.Spol,
                KontaktTel = x.KontaktTel
            }).ToList();




            UcenikVM ucenik = new UcenikVM() { UceniciPrikaz = uceniciVM };
            return View(ucenik);
        }

        public IActionResult Dodaj()
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            string[] spolovi = new string[] { "Muško", "Žensko" };

            UcenikVM ucenik = new UcenikVM() { Spolovi = spolovi };

            return View(ucenik);
        }

        public IActionResult Snimi(UcenikDodajVM i)
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            Ucenik ucenik = new Ucenik
            {
                Ime = i.Ime,
                Prezime = i.Prezime,
                DatRodj = DateOnly.FromDateTime(i.DatRodj.Value),
                Spol = i.Spol,
                KontaktTel = i.KontaktTel,
            };


            ucenikService.DodajUcenika(ucenik);

            return Redirect("/Ucenik/Prikaz");
        }
    }
}
