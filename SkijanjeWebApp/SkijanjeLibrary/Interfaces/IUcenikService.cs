using SkijanjeLibrary.FunctionModels;
using SkijanjeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkijanjeLibrary.Interfaces
{
    internal interface IUcenikService
    {
        Task<List<UcenikFM>> GetUcenikByInsId(int id);
        Task<List<Ucenik>> GetAll();
        void DodajUcenika(Ucenik u);
        public Task<Ucenik> GetUcenikByImePrezime(string imePrezime);
    }
}
