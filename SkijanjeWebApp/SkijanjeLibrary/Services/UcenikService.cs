using Microsoft.EntityFrameworkCore;
using Npgsql;
using SkijanjeLibrary.FunctionModels;
using SkijanjeLibrary.Interfaces;
using SkijanjeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkijanjeLibrary.Services
{
    public class UcenikService : IUcenikService
    {
        skijanje_db_ASPNETContext db = new skijanje_db_ASPNETContext();

        public void DodajUcenika(Ucenik u)
        {
            db.Add(u);
            db.SaveChanges();
        }

        public async Task<List<Ucenik>> GetAll()
        {
            var ucenici = await db.Uceniks.ToListAsync();

            return ucenici;
        }

        public async Task<Ucenik> GetUcenikByImePrezime(string imePrezime)
        {
            string[] ip = imePrezime.Split(" ");

            var ime = ip[0];
            var prezime = ip[1];

            var ucenik = await db.Uceniks.Where(x => x.Ime == ime && x.Prezime == prezime).FirstOrDefaultAsync();

            return ucenik;
        }

        public async Task<List<UcenikFM>> GetUcenikByInsId(int id)
        {
            var identifikator = new NpgsqlParameter("identifikator", NpgsqlTypes.NpgsqlDbType.Integer);

            identifikator.Value = id;

            var ucenik = await db.UcenikFMs.FromSqlRaw("select * from fn_Ucenik_select_by_instrukcija_id(@identifikator)", identifikator).ToListAsync();

            return ucenik;
        }
    }
}
