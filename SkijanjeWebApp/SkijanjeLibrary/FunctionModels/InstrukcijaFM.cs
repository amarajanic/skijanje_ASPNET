using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkijanjeLibrary.FunctionModels
{
    public class InstrukcijaFM
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public DateOnly Dat_odr { get; set; }
        public TimeOnly Termin { get; set; }
        public int Br_Cas { get; set; }

        public int Br_Ucen { get; set; }

        public int InstruktorId { get; set; }
    }
}
