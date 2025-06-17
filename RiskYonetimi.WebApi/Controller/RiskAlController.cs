using Microsoft.AspNetCore.Mvc;
using RiskYonetimi.Application.DTO;

namespace RiskYonetimi.WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RiskAlController : ControllerBase
    {//swaggerda gözükmesi için api katmanına eklendi
        [HttpPost]
        public IActionResult RiskAl([FromBody] RiskAnaliziDTO dto)
        {
            if (dto == null)
                return BadRequest("Geçersiz");
  
            return Ok();
        }
    }
}
 
