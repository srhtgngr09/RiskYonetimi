using Microsoft.AspNetCore.Mvc;
using RiskYonetimi.Application.DTO;
using RiskYonetimi.Application.FirmaBilgiAlService;
 
namespace RiskYonetimi.WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirmaBilgileri : ControllerBase
    {
        //Apicontroller sayfasında iş ortağından acenteden gelen bilgilerveritabanına eklendi
    private readonly IFirmaBilgileriAlService _service;
         public FirmaBilgileri(IFirmaBilgileriAlService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] FirmaBilgileriDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {//FirmaBilgileriAlService servisi çağrıldı ve bilgiler eklendi.
                var sonuc = await _service.SaveAsync(dto);

                if (!sonuc.Basarili)
                    return BadRequest(new { mesaj = sonuc.Mesaj });

                return Ok(new
                {
                    mesaj = "Kayıt başarılı",
                    anlasmaId = sonuc.AnlasmaId
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mesaj = "Sunucu hatası oluştu, lütfen tekrar deneyin." });
            }
        }
    }
}
