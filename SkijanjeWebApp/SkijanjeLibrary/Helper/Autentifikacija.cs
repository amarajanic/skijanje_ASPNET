using Microsoft.AspNetCore.Http;
using SkijanjeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkijanjeLibrary.Helper
{
    public static class Autentifikacija
    {
        public static void SetLogiraniKorisnik(this HttpContext httpContext, KorisnickiNalog k)
        {
            httpContext.Session.Set<KorisnickiNalog>("nekiKljucVarijabla", k);
        }

        public static KorisnickiNalog GetLogiraniKorisnik(this HttpContext httpContext)
        {
            var k = httpContext.Session.Get<KorisnickiNalog>("nekiKljucVarijabla");
            return k;
        }
    }
}
