using System;
using System.Collections.Generic;

namespace SkijanjeLibrary.Models
{
    public partial class Instruktor
    {
        public Instruktor()
        {
            Instrukcijas = new HashSet<Instrukcija>();
            Licencas = new HashSet<Licenca>();
        }

        public int Id { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public DateOnly? DatRodj { get; set; }
        public string? Spol { get; set; }
        public string? KontaktTel { get; set; }
        public DateOnly? SkijIsk { get; set; }
        public string? Biografija { get; set; }
        public byte[]? Cv { get; set; }

        


        public virtual ICollection<Instrukcija> Instrukcijas { get; set; }
        public virtual ICollection<Licenca> Licencas { get; set; }
    }
}
