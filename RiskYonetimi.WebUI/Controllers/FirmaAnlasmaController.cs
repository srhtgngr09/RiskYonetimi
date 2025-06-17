using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RiskYonetimi.Application.DTO;
using RiskYonetimi.Application.RiskGonderService;
using RiskYonetimi.Application.Tenant;
using RiskYonetimi.EF.Data;
using RiskYonetimi.WebUI.ViewModels;
using System;

namespace RiskYonetimi.WebUI.Controllers
{
    public class FirmaAnlasmaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITenant _tenant;
        private readonly IRiskGonderService _riskGonderService;

        public FirmaAnlasmaController(AppDbContext context, ITenant tenant, IRiskGonderService riskGonderService)
        {
            _context = context;
            _tenant = tenant;
            _riskGonderService = riskGonderService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {// webapi ile iş ortağından gelen dataları veritabanına eklenmiştir. Burada Index ile veritabanından gelen datalar önyüzde belli alanları doldruması için çağrılmıştır.
            var tenantId = _tenant.GetTenantId();

            var liste = await _context.Anlasmas
                .Where(a => a.TenantId == tenantId)
                .Select(a => new FirmaAnlasmaViewModel
                {
                    AnlasmaAdi = a.Ad,
                    SirketAdi = a.Sirket.Ad,
                    IsOrtagi = _context.IsOrtagis
                        .Where(io => io.TenantId == tenantId)
                        .Select(io => io.Ad)
                        .FirstOrDefault(),

                    IlAdlari = _context.AnlasmaIls
                        .Where(ai => ai.AnlasmaId == a.Id && ai.TenantId == tenantId)
                        .Select(ai => ai.Il.IlAdi)
                        .ToList(),

                    Konular = _context.AnlasmaKonus
                        .Where(ak => ak.AnlasmaId == a.Id && ak.TenantId == tenantId)
                        .Select(ak => ak.Konu.Konu)
                        .ToList(),

                    RiskPuani = _context.RiskAnalizis
                        .Where(r => r.AnlasmaId == a.Id && r.TenantId == tenantId)
                        .Select(r => r.RiskPuani)
                        .FirstOrDefault(),

                    RiskAciklama = _context.RiskAnalizis
                        .Where(r => r.AnlasmaId == a.Id && r.TenantId == tenantId)
                        .Select(r => r.Aciklama)
                        .FirstOrDefault(),

                    Tarih = _context.RiskAnalizis
                        .Where(r => r.AnlasmaId == a.Id && r.TenantId == tenantId)
                        .Select(r => r.Tarih)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return View(liste);
        }
        [HttpGet]
        public async Task<IActionResult> IlBazliRiskHesabi()
        {
            var tenantId = _tenant.GetTenantId();

            var riskler = await _context.RiskAnalizis
                .Where(r => r.TenantId == tenantId)
                .GroupBy(r => r.RiskPuani)
                .Select(g => new RiskAnalizViewModel
                {
                    RiskPuani = (int)g.Average(x => x.RiskPuani),
                    RiskSeviyesi = HesaplaSeviye((int)g.Average(x => x.RiskPuani))
                })
                .ToListAsync();

            return View(riskler);
        }
        [HttpPost]
        public async Task<IActionResult> IlBazliRiskHesabi(List<RiskAnalizViewModel> model)
        {//Burada riskin hesaplanıp ekrandan iş ortağına iletilmesi için gönderimi yapıldı.
            if (!ModelState.IsValid)
                return View(model);

            foreach (var risk in model)
            {
                var riskAnaliziDto = new RiskAnaliziDTO
                {
                    IlAdi = risk.IlAdi,
                    RiskPuani = risk.RiskPuani,
                    RiskSeviyesi = risk.RiskSeviyesi
                };
                var sonuc = await _riskGonderService.GonderAsync(riskAnaliziDto);

            }

            TempData["Mesaj"] = "Risk analizleri anlaşmalı şirkete iletildi.";
            return RedirectToAction("IlBazliRiskHesabi");
        }
        private string HesaplaSeviye(int puan)
        {//bu metotda riskin seviyesi demo olarak belirlendi.
            if (puan >= 80) return "Çok Yüksek";
            if (puan >= 60) return "Yüksek";
            if (puan >= 40) return "Orta";
            if (puan >= 20) return "Düşük";
            return "Çok Düşük";
        }
    }
     
}
