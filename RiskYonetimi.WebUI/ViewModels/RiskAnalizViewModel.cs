using System.ComponentModel.DataAnnotations;

namespace RiskYonetimi.WebUI.ViewModels
{
    public class RiskAnalizViewModel
    {
        public string IlAdi { get; set; }

        [Required]
        public int RiskPuani { get; set; }

        public string RiskSeviyesi { get; set; }
    }
}
