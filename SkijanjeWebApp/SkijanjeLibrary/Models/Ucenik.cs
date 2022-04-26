using System;
using System.Collections.Generic;

namespace SkijanjeLibrary.Models
{
    public partial class Ucenik
    {
        public Ucenik()
        {
            OpremaUceniks = new HashSet<OpremaUcenik>();
            UcenikInstrukcijas = new HashSet<UcenikInstrukcija>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateOnly? DatRodj { get; set; }
        public string Spol { get; set; }
        public string KontaktTel { get; set; }

        public virtual ICollection<OpremaUcenik> OpremaUceniks { get; set; }
        public virtual ICollection<UcenikInstrukcija> UcenikInstrukcijas { get; set; }
    }
}
