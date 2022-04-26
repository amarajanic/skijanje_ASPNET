using System;
using System.Collections.Generic;

namespace SkijanjeLibrary.Models
{
    public partial class OpremaUcenik
    {
        public int Id { get; set; }
        public int? Kolicina { get; set; }
        public DateOnly? DatIzd { get; set; }
        public int Opremaid { get; set; }
        public int Ucenikid { get; set; }
        public int? Instrukcijaid { get; set; }

        public virtual Instrukcija? Instrukcija { get; set; }
        public virtual Oprema Oprema { get; set; } = null!;
        public virtual Ucenik Ucenik { get; set; } = null!;
    }
}
