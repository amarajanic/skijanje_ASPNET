using SkijanjeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkijanjeLibrary.Interfaces
{
    internal interface IAutentifikacijaService
    {
        Task<KorisnickiNalog> ProvjeriLogin(string username, string password);
    }
}
