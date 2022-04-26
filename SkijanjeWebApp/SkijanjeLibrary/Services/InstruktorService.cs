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
    public class InstruktorService : IInstruktorService
    {
        skijanje_db_ASPNETContext db = new skijanje_db_ASPNETContext();
        public async Task<List<Instruktor>> GetAll()
        {
            var instruktori = await db.Instruktors.ToListAsync();

            return instruktori;
        }

        public async Task<int> GetInstruktorId(string ip)
        {
            string[] imePrezime = ip.Split(" ");

            int id = await db.Instruktors.Where(x => (x.Ime == imePrezime[0] && x.Prezime == imePrezime[1])).Select(x => x.Id).FirstOrDefaultAsync();

            return id;
        }

        public void DodajInstruktora(Instruktor i)
        {
            db.Add(i);
            db.SaveChanges();
        }

        public async Task<Instruktor> GetInstruktorById(int id)
        {
            var instruktor = await db.Instruktors.Where(x => x.Id == id).FirstOrDefaultAsync();

            return instruktor;
        }
    }
}
