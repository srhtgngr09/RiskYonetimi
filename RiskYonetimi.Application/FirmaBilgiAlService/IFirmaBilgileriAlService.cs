using RiskYonetimi.Application.DTO;

namespace RiskYonetimi.Application.FirmaBilgiAlService
{
    //İş ortağının gönderdiği anlaşmaya göre veritabanına yazılan servisin interface i oluşturuldu.
    public interface IFirmaBilgileriAlService
    {
          Task<SorguSonucuDTO> SaveAsync(FirmaBilgileriDTO dto);

    }
}
