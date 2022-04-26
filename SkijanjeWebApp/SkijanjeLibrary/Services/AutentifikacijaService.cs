using Microsoft.EntityFrameworkCore;
using SkijanjeLibrary.Interfaces;
using SkijanjeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkijanjeLibrary.Services
{
    public class AutentifikacijaService : IAutentifikacijaService
    {
        skijanje_db_ASPNETContext db = new skijanje_db_ASPNETContext();
        public async Task<KorisnickiNalog> ProvjeriLogin(string username, string password)
        {
            var korisnik = new List<KorisnickiNalog>();
          
            korisnik = await db.KorisnickiNalogs.Where(x => x.Username == username && x.Password == password).ToListAsync();
            
            if(korisnik.Count > 0)
            {
                return korisnik[0];
            }
            else
            {
                return null;
            }
        }
    }
}
