namespace SkijanjeASPNET.Models
{
    public class InstrukcijaVM
    {
        public int InstrukcijaId { get; set; }
        public List<InstrukcijaPrikazVM> InstrukcijaPrikaz { get; set; }
        public List<InstruktorImeVM> Instruktori { get; set; }
        public List<InstrukcijaDetaljiVM> InstrukcijaDetalji { get; set; }

        public List<UcenikPrikazVM> UcenikPrikaz { get; set; }
        public List<UcenikImeVM> UceniciSvi { get; set; }

        public InstruktorImeVM Instruktor { get; set; }

        public string datumPocetak { get; set; }
        public string datumKraj { get; set; }


    }
}
