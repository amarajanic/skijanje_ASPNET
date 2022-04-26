using SkijanjeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkijanjeLibrary.Interfaces
{
    interface IInstruktorService
    {
        Task<List<Instruktor>> GetAll();

        Task<int> GetInstruktorId(string imePrezime);

        void DodajInstruktora(Instruktor i);

        Task<Instruktor> GetInstruktorById(int id);

    }
}
