using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RiskYonetim.Domain.Model;
using RiskYonetimi.Application.DTO;
using RiskYonetimi.Application.Tenant;
using RiskYonetimi.EF.Data;

namespace RiskYonetimi.Application.FirmaBilgiAlService
{
    //İş ortağından gelen bilgileri alan servisin interface i burada yazıldı.Tenant id ile iş ortağının gönderdiği veriler bu şirket için özelleştirildi.Sigorta sektöründe çalıştığım için kurguyu iş ortakları olarak Acenteyi belirledim.ve Acentelerin il bazlı risk analizlerini düşünerek demoyu oluşturdum.Katmanlı mimariyi asp.net boilerplate framework ünden katmanlarından referans alarak sıfırdan oluşturdum.
    public class FirmaBilgileriAlService : IFirmaBilgileriAlService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITenant _tenant;
        public  FirmaBilgileriAlService(AppDbContext context, IMapper mapper, ITenant tenant)
        {
            _context = context;
            _mapper = mapper;
            _tenant = tenant;
        }



        public async Task<SorguSonucuDTO> SaveAsync(FirmaBilgileriDTO dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var tenantId = _tenant.GetTenantId();
                //   Firma kontrolü yapılıyor
                var sirket = await _context.Sirkets.AsNoTracking()
                    .FirstOrDefaultAsync(s => s.Ad == dto.SirketAdi && s.TenantId == tenantId);

                if (sirket == null)
                {
                    sirket = new Sirket { Ad = dto.SirketAdi, TenantId = tenantId };
                    _context.Sirkets.Add(sirket);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Attach(sirket);
                }

                // iş ortağının anlaşması tabloya eklenir.
                var anlasma = new Anlasma
                {
                    Ad = dto.AnlasmaAdi,
                    SirketId = sirket.Id,
                    BaslangicTarihi = DateTime.Now,
                    TenantId = tenantId
                };
                _context.Anlasmas.Add(anlasma);
                await _context.SaveChangesAsync();

                // önce ilin var olup olmadığı kontrolü yapıldı yok ise tabloya eklendi.
                var ilListesi = await _context.IlAdis
                    .Where(il => dto.Iller.Contains(il.IlAdi) && il.TenantId == tenantId)
                    .ToListAsync();

                foreach (var il in ilListesi)
                {
                    _context.AnlasmaIls.Add(new AnlasmaIl
                    {
                        AnlasmaId = anlasma.Id,
                        IlId = il.Id,
                        TenantId = tenantId
                    });
                }

                // iş ortağının anlaşma teklifinde mevcut konu olup olmadığına bakıldı. Tabloda olmayan konu eklendi.
                var konuListesi = await _context.IsKonus
                    .Where(k => dto.Konular.Contains(k.Konu) && k.TenantId == tenantId)
                    .ToListAsync();

                foreach (var konu in konuListesi)
                {
                    _context.AnlasmaKonus.Add(new AnlasmaKonulari
                    {
                        AnlasmaId = anlasma.Id,
                        KonuId = konu.Id,
                        TenantId = tenantId
                    });
                }

                // iş ortağı ilk defamı anlaşma teklifi gönderdiği yoksa daha önceden olup olmadığı kontrol edildi.
                var ortak = await _context.IsOrtagis.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Ad == dto.IsOrtagi && x.TenantId == tenantId);

                if (ortak == null)
                {
                    ortak = new IsOrtagi { Ad = dto.IsOrtagi, TenantId = tenantId };
                    _context.IsOrtagis.Add(ortak);
                }

                // Anlaşma konusunun servisle gelen risk puanı ve acıklaması eklendi
                var risk = new RiskAnalizi
                {
                    AnlasmaId = anlasma.Id,
                    RiskPuani = dto.RiskPuani,
                    Aciklama = dto.RiskAciklama,
                    Tarih = DateTime.Now,
                    TenantId = tenantId
                };

                _context.RiskAnalizis.Add(risk);

                // burada tm kayıtlar savechange ile tabloya eklenmesi sağlandı.
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return new SorguSonucuDTO
                {
                    Basarili = true,
                    AnlasmaId = anlasma.Id,
                    Mesaj = "Kayıt tamamlandı"
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                
                return new SorguSonucuDTO
                {
                    Basarili = false,
                    Mesaj = "Hata oluştu: " + ex.Message
                };
            }
        }
        
    }
}
