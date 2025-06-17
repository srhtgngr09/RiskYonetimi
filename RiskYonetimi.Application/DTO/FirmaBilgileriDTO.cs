namespace RiskYonetimi.Application.DTO
{
    public class FirmaBilgileriDTO
    {
        public string SirketAdi { get; set; }
        public string AnlasmaAdi { get; set; }
        public List<string> Iller { get; set; }
        public List<string> Konular { get; set; }
        public string IsOrtagi { get; set; }
        public int RiskPuani { get; set; }
        public string RiskAciklama { get; set; }
    }
}
