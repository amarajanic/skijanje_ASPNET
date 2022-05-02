using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SkijanjeASPNET.Models
{
    public class InstruktorPrikazVM
    {
        [Required]
        public string? Ime { get; set; }
        [Required]

        public string? Prezime { get; set; }
        [Required]

        public DateTime? DatRodj { get; set; }
        [Required]

        public string? Spol { get; set; }
        [Required]

        public string? KontaktTel { get; set; }
        [Required]

        public DateTime? SkijIsk { get; set; }
        [Required]

        public string? Biografija { get; set; }
        [Required]

        public IFormFile? Cv { get; set; }
    }
}
