using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkijanjeASPNET.Models;
using SkijanjeLibrary.Models;
using SkijanjeLibrary.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SkijanjeLibrary.Helper;

namespace SkijanjeASPNET.Controllers
{
    public class InstrukcijaController : Controller
    {
        InstrukcijaService instrukcijaService = new InstrukcijaService();
        InstruktorService instruktorService = new InstruktorService();
        UcenikService ucenikService = new UcenikService();

        public async Task<IActionResult> Prikaz(string i, DateTime p, DateTime k)
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            InstrukcijaVM instrukcijaPrikaz = new InstrukcijaVM();


            var instruktori = await instruktorService.GetAll();

           List<InstruktorImeVM> instruktoriVM = new List<InstruktorImeVM>();
            instruktoriVM.Add(new InstruktorImeVM { ImePrezime = " " });

        

            instruktoriVM.AddRange(instruktori.Select(x => new InstruktorImeVM {
                ImePrezime = x.Ime + " " + x.Prezime
            }).ToList());

            string[] imePrezime =new string[2];
            if(i != null)
            {
                imePrezime = i.Split(" ");
            }
            else
            {
                imePrezime[0] = String.Empty;
                imePrezime[1] = String.Empty;
            }

            instrukcijaPrikaz.datumPocetak = DateTime.Now.ToString("yyyy-MM-dd");

            instrukcijaPrikaz.datumKraj = DateTime.Now.AddDays(6).ToString("yyyy-MM-dd");

            if(p == DateTime.Parse("01/01/0001 00:00:00"))
            {
                p = DateTime.Parse(instrukcijaPrikaz.datumPocetak);
            }

            if(k == DateTime.Parse("01/01/0001 00:00:00"))
            {
                k = DateTime.Parse(instrukcijaPrikaz.datumKraj);
            
            }

            var instrukcije = await instrukcijaService.GetInstrukcijaByInstruktorAndDate(imePrezime[0], imePrezime[1], p, k);

            var instrukcijeVM = instrukcije.Select(x => new InstrukcijaPrikazVM
            {
                Id = x.ID,
                Ime = x.Ime,
                Prezime = x.Prezime,
                DatumOdr = x.Dat_odr,
                BrUcen = x.Br_Ucen,
                Termin = x.Termin,
                BrCas = x.Br_Cas
            }).ToList();


            instrukcijaPrikaz.InstrukcijaPrikaz = instrukcijeVM;
            instrukcijaPrikaz.Instruktori = instruktoriVM;


            return View(instrukcijaPrikaz);
        }

        public async Task<IActionResult> Dodaj()
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            var instruktori = await instruktorService.GetAll();
            List<InstruktorImeVM> instruktoriVM = new List<InstruktorImeVM>();
            instruktoriVM.Add(new InstruktorImeVM { ImePrezime = " " });
            instruktoriVM.AddRange(instruktori.Select(x => new InstruktorImeVM
            {
                ImePrezime = x.Ime + " " + x.Prezime
            }).ToList());



            var instruktorVM = new InstruktorVM() { InstruktorImePrezime = instruktoriVM };
            return View(instruktorVM);
        }

        public async Task<IActionResult> Snimi(DateTime datum, TimeSpan vrijeme, int brojCas, string instruktor, string biljeske)
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            int id = await instruktorService.GetInstruktorId(instruktor);

            Instrukcija i = new Instrukcija()
            {
                DatumOdr = datum,
                Termin = vrijeme,
                BrojCas = brojCas,
                Biljeske = biljeske,
                Instruktorid = id
            };

            instrukcijaService.DodajInstrukciju(i);

            return Redirect("/Instrukcija/Prikaz");
        }

        public async Task<IActionResult> Spremi(DateTime datum, TimeSpan vrijeme, int brojCas, string instruktor, string biljeske)
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            int id = await instruktorService.GetInstruktorId(instruktor);

            Instrukcija i = new Instrukcija()
            {
                DatumOdr = datum,
                Termin = vrijeme,
                BrojCas = brojCas,
                Biljeske = biljeske,
                Instruktorid = id
            };

            instrukcijaService.UrediInstrukciju(i);

            return Redirect("/Instrukcija/Prikaz");
        }

        [HttpGet]
        public async Task<IActionResult> Detalji(int id)
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            var instrukcija = await instrukcijaService.GetInstrukcijaById(id);

            var ucenici = await ucenikService.GetUcenikByInsId(id);

            var uceniciVM = ucenici.Select(x => new UcenikPrikazVM
            {
                Ime = x.Ime,
                Prezime = x.Prezime,
                Spol = x.Spol,
                DatRodj =x.Dat_Rodj,
                KontaktTel = x.Kontakt_Tel
            }).ToList();

            var instrukcijaVM = new InstrukcijaDetaljiVM
            {
                DatumOdr = instrukcija.DatumOdr,
                Termin = instrukcija.Termin,
                BrojCas = instrukcija.BrojCas,
                Biljeske = instrukcija.Biljeske
            };





            InstrukcijaVM instrukcijaPrikaz = new InstrukcijaVM() {UcenikPrikaz = uceniciVM , InstrukcijaDetalji = new List<InstrukcijaDetaljiVM>()};

            instrukcijaPrikaz.InstrukcijaDetalji.Add(instrukcijaVM);


            return View(instrukcijaPrikaz);
        }

        public async Task<IActionResult> Uredi(int id)
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            var instrukcija = await instrukcijaService.GetInstrukcijaById(id);

            var instruktor = await instruktorService.GetInstruktorById(instrukcija.Instruktorid);

            var instruktori = await instruktorService.GetAll();


            var instruktorVM = new InstruktorImeVM
            {
                ImePrezime = instruktor.Ime + " " + instruktor.Prezime
            };

       

            var instrukcijaVM = new InstrukcijaDetaljiVM
            {
                DatumOdr = instrukcija.DatumOdr,
                Termin = instrukcija.Termin,
                BrojCas = instrukcija.BrojCas,
                Biljeske = instrukcija.Biljeske
            };

            var instruktoriVM = instruktori.Select(x => new InstruktorImeVM
            {
                //Ime = x.Ime,
                //Prezime = x.Prezime,
                //DatRodj = DateTime.Parse(x.DatRodj.Value.ToString()),
                //KontaktTel = x.KontaktTel,
                //Spol = x.Spol,
                //Biografija = x.Biografija,
                //SkijIsk = DateTime.Parse(x.SkijIsk.Value.ToShortDateString())
                ImePrezime = x.Ime + " " + x.Prezime
            }).ToList();

 
            var instrukcijaPrikaz = new InstrukcijaVM() { Instruktori = instruktoriVM, Instruktor = instruktorVM, InstrukcijaDetalji = new List<InstrukcijaDetaljiVM>() };
            instrukcijaPrikaz.InstrukcijaDetalji.Add(instrukcijaVM);
            return View(instrukcijaPrikaz);
        }

        public async Task<IActionResult> Ucenici(int id)
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            var ucenici = await ucenikService.GetUcenikByInsId(id);

            var uceniciSvi = await ucenikService.GetAll();

            for (int i = 0; i < ucenici.Count; i++)
            {
                for (int j = 0; j < uceniciSvi.Count; j++)
                {
                    if (uceniciSvi[j].Id == ucenici[i].Id)
                    {
                        uceniciSvi.RemoveAt(j);
                    }
                }
            }
            var uceniciVM = ucenici.Select(x => new UcenikPrikazVM
            {
                Ime = x.Ime,
                Prezime = x.Prezime,
                Spol = x.Spol,
                DatRodj = x.Dat_Rodj,
                KontaktTel = x.Kontakt_Tel
            }).ToList();

            var uceniciSviVM = uceniciSvi.Select(x => new UcenikImeVM
            {
               ImePrezime = x.Ime + " " + x.Prezime
                
            }).ToList();

            //ViewData["ucenici"] = uceniciVM;
            //ViewData["uceniciSvi"] = uceniciSviVM;
            //ViewData["instrukcijaId"] = id;

            var instrukcija = new InstrukcijaVM { UcenikPrikaz = uceniciVM, UceniciSvi = uceniciSviVM, InstrukcijaId = id };

            return View(instrukcija);
        }

        public async Task<ActionResult> SpasiUcenika(int id, string ime)
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            var ucenik = await ucenikService.GetUcenikByImePrezime(ime);

           // var instrukcija = await instrukcijaService.GetInstrukcijaById(id);

            instrukcijaService.DodajUcenikInstrukciju(id, ucenik.Id);

            return Redirect("/Instrukcija/Ucenici");
        }

        public ActionResult Obrisi(int id)
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            var model = new InstrukcijaVM { InstrukcijaId = id };

            return View("ObrisiPoruka", model);
        }

        public ActionResult ObrisiPoruka(InstrukcijaVM instrukcija)
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            return View(instrukcija);
        }

        public ActionResult ObrisiPotvrda(int instrukcijaId)
        {
            if (HttpContext.GetLogiraniKorisnik() == null)
                return Redirect("/Autentifikacija/Index");

            instrukcijaService.ObrisiInstrukciju(instrukcijaId);

            return Redirect("/Instrukcija/Prikaz");
        }

        // GET: InstrukcijaController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: InstrukcijaController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: InstrukcijaController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: InstrukcijaController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: InstrukcijaController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: InstrukcijaController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: InstrukcijaController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: InstrukcijaController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
