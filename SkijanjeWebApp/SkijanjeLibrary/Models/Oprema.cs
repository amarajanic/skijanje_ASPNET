using System;
using System.Collections.Generic;

namespace SkijanjeLibrary.Models
{
    public partial class Oprema
    {
        public Oprema()
        {
            OpremaUceniks = new HashSet<OpremaUcenik>();
        }

        public int Id { get; set; }
        public string? Naziv { get; set; }
        public double? Cijena { get; set; }
        public int? Kolicina { get; set; }
        public int? Markaid { get; set; }
        public int? Modelid { get; set; }

        public virtual Marka? Marka { get; set; }
        public virtual Model? Model { get; set; }
        public virtual ICollection<OpremaUcenik> OpremaUceniks { get; set; }
    }
}
