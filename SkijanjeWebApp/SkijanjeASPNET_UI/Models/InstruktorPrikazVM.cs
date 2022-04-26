using Microsoft.AspNetCore.Http;

namespace SkijanjeASPNET.Models
{
    public class InstruktorPrikazVM
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public DateTime? DatRodj { get; set; }
        public string? Spol { get; set; }
        public string? KontaktTel { get; set; }
        public DateTime? SkijIsk { get; set; }
        public string? Biografija { get; set; }
        public IFormFile? Cv { get; set; }
    }
}
