namespace RiskYonetim.Domain.Model
{
    //Bu class yapılan anlaşmanın hangi ilden geldiğini belirtiyor.
    public class AnlasmaIl
    {
        public int Id { get; set; }
        public int AnlasmaId { get; set; }
        public Anlasma Anlasma { get; set; }
        public int IlId { get; set; }
        public IlAd Il { get; set; }
        public int TenantId { get; set; }
    }
}
