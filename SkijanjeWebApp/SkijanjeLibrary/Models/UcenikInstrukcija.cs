using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkijanjeLibrary.Models
{
    public class UcenikInstrukcija
    {
        public int Ucenikid { get; set; }
        public int Instrukcijaid { get; set; }

        public virtual Instrukcija Instrukcija { get; set; }
        public virtual Ucenik Ucenik { get; set; }
    }
}
