namespace SkijanjeASPNET.Models
{
    public class InstrukcijaPrikazVM
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public DateOnly DatumOdr { get; set; }
        public TimeOnly Termin { get; set; }
        public int BrCas { get; set; }

        public int BrUcen { get; set; }

    }
}
