using RiskYonetimi.Application.DTO;

namespace RiskYonetimi.Application.RiskGonderService
{
    public class RiskGonderService : IRiskGonderService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RiskGonderService> _logger;

        public RiskGonderService(HttpClient httpClient, ILogger<RiskGonderService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<bool> GonderAsync(RiskAnaliziDTO dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:5001/api/riskal", dto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Risk gönderme sırasında hata oluştu");
                return false;
            }
        }

      
    }
}
