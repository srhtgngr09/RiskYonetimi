using System.ComponentModel.DataAnnotations;

namespace RiskYonetim.Domain.Model
{
    //Bu class işortağı şirket bilgilerini tutuyor.
    public class IsOrtagi
    {
        public int Id { get; set; }
         
        [Required]
        public string Ad { get; set; }

        public string Tip { get; set; } 

        [MaxLength(150)]
        public string IletisimKisi { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Telefon { get; set; }
        public int TenantId { get; set; }
    }
}
