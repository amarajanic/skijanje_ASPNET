namespace SkijanjeASPNET.Models
{
    public class InstruktorVM
    {
        public List<InstruktorImeVM> InstruktorImePrezime { get; set; }
        public List<InstruktorPrikazVM> InstruktorPrikaz { get; set; }
        public string[] Spolovi { get; set; }

        public InstruktorPrikazVM InstruktorDodaj { get; set; }

        public string datumOdr { get; set; }
        public string vrijemeOdr { get; set; }

    }
}
