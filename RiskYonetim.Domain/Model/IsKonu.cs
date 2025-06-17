using System.ComponentModel.DataAnnotations;

namespace RiskYonetim.Domain.Model
{
    //Bu class anlaşma konuları tutan entity içeriyor.
    public class IsKonu
    {  
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Konu { get; set; }
        public int TenantId { get; set; }
        public ICollection<AnlasmaKonulari> AnlasmaKonular { get; set; }
    }
}
