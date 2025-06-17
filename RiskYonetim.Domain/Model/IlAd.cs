using System.ComponentModel.DataAnnotations;

namespace RiskYonetim.Domain.Model
{
    //Bu class İl adına göre o ile bağlı firmadaki anlaşmaların ettity bloğunu içeriyor.
    public class IlAd
    { 
        public int Id { get; set; }
        [MaxLength(50)]
        public string IlAdi { get; set; }
        public int TenantId { get; set; }
        public ICollection<AnlasmaIl> AnlasmaIller { get; set; }
    }
}
