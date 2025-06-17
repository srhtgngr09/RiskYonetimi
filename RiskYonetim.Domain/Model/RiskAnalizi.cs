using System.ComponentModel.DataAnnotations;

namespace RiskYonetim.Domain.Model
{
    //Bu class il bazlı anlaşmalı ortağın il bazlı risk bilgilerinin iletildiği entity içeriyor.
    public class RiskAnalizi
    {
        public int Id { get; set; }

        public int AnlasmaId { get; set; }
        public Anlasma Anlasma { get; set; }

        [Required]
        [MaxLength(100)]
        public string RiskSeviyesi { get; set; } 
        [Required]
        public int RiskPuani { get; set; }
  
        [MaxLength(500)]
        public string Aciklama { get; set; }

        public DateTime Tarih { get; set; }
        public int TenantId { get; set; }
    }
}
