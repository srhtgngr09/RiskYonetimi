namespace RiskYonetimi.WebUI.ViewModels
{
    public class FirmaAnlasmaViewModel
    {
        public string AnlasmaAdi { get; set; }
        public string SirketAdi { get; set; }
        public string IsOrtagi { get; set; }
        public List<string> IlAdlari { get; set; }
        public List<string> Konular { get; set; }
        public int RiskPuani { get; set; }
        public string RiskAciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}
