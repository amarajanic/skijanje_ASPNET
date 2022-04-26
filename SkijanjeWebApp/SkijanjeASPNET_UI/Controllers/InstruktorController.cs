using Microsoft.AspNetCore.Mvc;
using SkijanjeASPNET.Models;
using SkijanjeLibrary.Models;
using SkijanjeLibrary.Services;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SkijanjeLibrary.Helper;

namespace SkijanjeASPNET.Controllers
{
    public class InstruktorController : Controller
    {
        InstruktorService instruktorService = new InstruktorService();
        //public async Task<IActionResult> Index()
        //{
        //    if (HttpContext.GetLogiraniKorisnik() == null)
        //        return Redirect("/Autentifikacija/Index");


        //    return View();
        //}

        public async Task<IActionResult> Prikaz()
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            var instruktori = await instruktorService.GetAll();

            var instruktoriVM = instruktori.Select(x => new InstruktorPrikazVM
            {
                Ime = x.Ime,
                Prezime = x.Prezime,
                DatRodj = DateTime.Parse(x.DatRodj.Value.ToString()),
                KontaktTel = x.KontaktTel,
                Spol = x.Spol,
                Biografija = x.Biografija,
                SkijIsk = DateTime.Parse(x.SkijIsk.Value.ToShortDateString())
            }).ToList();


            InstruktorVM instruktorVM = new InstruktorVM() { InstruktorPrikaz = instruktoriVM };

            return View(instruktorVM);
        }

        public IActionResult Dodaj()
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            string[] spolovi = new string[] { "Muško", "Žensko" };

            ViewData["spolovi"] = spolovi;
            InstruktorVM instruktorVM = new InstruktorVM() { Spolovi = spolovi};

            return View(instruktorVM);
        }
     
        public IActionResult Snimi(InstruktorPrikazVM i)
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            FileHelper fh = new FileHelper();
            byte[] cv = fh.FileToByteArray(i.Cv);

            Instruktor instruktor = new Instruktor()
            {
                Ime = i.Ime,
                Prezime = i.Prezime,
                DatRodj = DateOnly.Parse(i.DatRodj.Value.ToShortDateString()),
                Spol = i.Spol,
                Biografija = i.Biografija,
                KontaktTel = i.KontaktTel,
                SkijIsk = DateOnly.Parse(i.SkijIsk.Value.ToShortDateString()),
                Cv = cv
            };

      
            instruktorService.DodajInstruktora(instruktor);

            return Redirect("/Instruktor/Prikaz");
        }
    }
}
