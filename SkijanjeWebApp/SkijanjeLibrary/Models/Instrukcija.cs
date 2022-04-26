using System;
using System.Collections.Generic;

namespace SkijanjeLibrary.Models
{
    public partial class Instrukcija
    {
        public Instrukcija()
        {
            OpremaUceniks = new HashSet<OpremaUcenik>();
            UcenikInstrukcijas = new HashSet<UcenikInstrukcija>();
        }

        public int Id { get; set; }
        public DateTime? DatumOdr { get; set; }
        public TimeSpan? Termin { get; set; }
        public int? BrojCas { get; set; }
        public string Biljeske { get; set; }
        public int Instruktorid { get; set; }

        public virtual Instruktor Instruktor { get; set; }
        public virtual ICollection<OpremaUcenik> OpremaUceniks { get; set; }
        public virtual ICollection<UcenikInstrukcija> UcenikInstrukcijas { get; set; }
    }
}
