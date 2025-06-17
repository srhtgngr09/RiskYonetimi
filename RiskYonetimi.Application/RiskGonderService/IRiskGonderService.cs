using RiskYonetimi.Application.DTO;

namespace RiskYonetimi.Application.RiskGonderService
{
    public interface IRiskGonderService
    {
        Task<bool> GonderAsync(RiskAnaliziDTO dto);

    }
}
