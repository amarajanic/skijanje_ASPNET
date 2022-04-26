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
    public class InstrukcijaService : IInstrukcijaService
    {
        skijanje_db_ASPNETContext db = new skijanje_db_ASPNETContext();

        public void DodajInstrukciju(Instrukcija i)
        {
            db.Add(i);
            db.SaveChanges();
        }

        public void UrediInstrukciju(Instrukcija i)
        {
           //odraditi pomoću pg funkcije...
            db.Instrukcijas.Update(i);
            //db.Update(i);
            db.SaveChanges();
        }

        public async Task<List<InstrukcijaFM>> GetInstrukcijaByInstruktorAndDate(string i, string pr, DateTime po, DateTime k)
        {
            var pocetak = new NpgsqlParameter("pocetak", NpgsqlTypes.NpgsqlDbType.Date);

            var kraj = new NpgsqlParameter("kraj", NpgsqlTypes.NpgsqlDbType.Date);

            var ime = new NpgsqlParameter("ime", NpgsqlTypes.NpgsqlDbType.Varchar);

            var prezime = new NpgsqlParameter("prezime", NpgsqlTypes.NpgsqlDbType.Varchar);

            pocetak.Value = po;
            kraj.Value = k;
            ime.Value = i;
            prezime.Value = pr;

            var instrukcije = await db.InstrukcijaFMs.FromSqlRaw("select * from fn_Instruktor_select_by_ime_prezime_datum(@ime,@prezime,@pocetak,@kraj)", ime, prezime, pocetak, kraj).ToListAsync();


            return instrukcije;
        }

        public async Task<Instrukcija> GetInstrukcijaById(int id)
        {
           var instrukcija =  await db.Instrukcijas.Where(x => x.Id == id).FirstOrDefaultAsync();

           return instrukcija;
        }

        public void DodajUcenikInstrukciju(int instrukcijaId, int ucenikId)
        {
            db.UcenikInstrukcijas.Add(new UcenikInstrukcija { Instrukcijaid = instrukcijaId,Ucenikid=ucenikId });
            db.SaveChanges();
        }

        public void ObrisiInstrukciju(int id)
        {
            Instrukcija i = new Instrukcija() { Id = id };
            db.Instrukcijas.Attach(i);
            db.Instrukcijas.Remove(i);
            db.SaveChanges();
        }
    }
}
