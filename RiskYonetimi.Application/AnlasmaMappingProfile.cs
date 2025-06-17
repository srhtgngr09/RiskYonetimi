using AutoMapper;
using RiskYonetim.Domain.Model;
using RiskYonetimi.Application.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RiskYonetimi.Application
{
    public class AnlasmaMappingProfile : Profile
    {
        public AnlasmaMappingProfile()
        {
            CreateMap<FirmaBilgileriDTO, Anlasma>();
        }
    }
}
