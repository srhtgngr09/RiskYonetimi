namespace RiskYonetim.Domain.Model
{
    //Bu class Anlasma tablosuyla anlaşmaya bağlı konuları getiren entity içeriyor
    public class AnlasmaKonulari
    {
        public int Id { get; set; }
        public int AnlasmaId { get; set; }
        public Anlasma Anlasma { get; set; }
        public int KonuId { get; set; }
        public IsKonu Konu { get; set; }
        public int TenantId { get; set; }
    }
}
