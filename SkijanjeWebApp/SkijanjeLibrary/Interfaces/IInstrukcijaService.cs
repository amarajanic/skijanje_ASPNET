using SkijanjeLibrary.FunctionModels;
using SkijanjeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkijanjeLibrary.Interfaces
{
    internal interface IInstrukcijaService
    {
        public Task<List<InstrukcijaFM>> GetInstrukcijaByInstruktorAndDate(string ime, string prezime, DateTime pocetak, DateTime kraj);

        public void DodajInstrukciju(Instrukcija i);
        public void UrediInstrukciju(Instrukcija i);
        public void ObrisiInstrukciju(int id);

        public Task<Instrukcija> GetInstrukcijaById(int id);

        public void DodajUcenikInstrukciju(int instrukcijaId, int ucenikId);

    }
}
