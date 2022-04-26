namespace SkijanjeASPNET.Models
{
    public class UcenikVM
    {
        public string[] Spolovi { get; set; }

        public List<UcenikPrikazVM> UceniciPrikaz { get; set; }

        public UcenikDodajVM UcenikDodaj { get; set; }
    }
}
