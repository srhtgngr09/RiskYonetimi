using System.ComponentModel.DataAnnotations;

namespace RiskYonetim.Domain.Model
{
    //Bu class  firmanın hangi iş ortağı ile anlaşma yaptığını alan entity içeriyor.
    public class Anlasma
    {
        public int Id { get; set; }
         [Required]
        [MaxLength(150)]
        public string Ad { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public int SirketId { get; set; }
        public Sirket Sirket { get; set; }
        public int TenantId { get; set; }
        public ICollection<AnlasmaKonulari> AnlasmaKonular { get; set; }
        public ICollection<AnlasmaIl> AnlasmaIller { get; set; }
        public ICollection<RiskAnalizi> RiskAnalizleri { get; set; }
    }
}
