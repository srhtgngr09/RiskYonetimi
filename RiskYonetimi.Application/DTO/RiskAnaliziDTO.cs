namespace RiskYonetimi.Application.DTO
{
    public class RiskAnaliziDTO
    {
        public int Id { get; set; }
        public int AnlasmaId { get; set; }
        public string IlAdi { get; set; }
        public string RiskSeviyesi { get; set; }
        public int RiskPuani { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}
