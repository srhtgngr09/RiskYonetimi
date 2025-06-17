using System.ComponentModel.DataAnnotations;

namespace RiskYonetim.Domain.Model
{
    //Ana şirketin bilgilerini tutan entity içeriyor.
    public class Sirket
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Ad { get; set; }

        [MaxLength(50)]
        public string VergiNo { get; set; }

        [MaxLength(150)]
        public string YetkiliKisi { get; set; }

        public string Telefon { get; set; }
        public int TenantId { get; set; }
        public ICollection<Anlasma> Anlasmalar { get; set; }
    }
}
