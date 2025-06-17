using Microsoft.EntityFrameworkCore;
using RiskYonetim.Domain.Model;
using RiskYonetimi.Application.Tenant;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RiskYonetimi.EF.Data
{
    //Tüm entitylerin contextleri bu katmanda tanımlandı.
    public class AppDbContext : DbContext
    {
        private readonly ITenant _tenant;
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Anlasma> Anlasmas { get; set; }
        public DbSet<AnlasmaIl> AnlasmaIls { get; set; }
        public DbSet<AnlasmaKonulari> AnlasmaKonus { get; set; }
        public DbSet<IlAd> IlAdis { get; set; }
        public DbSet<IsKonu> IsKonus { get; set; }
        public DbSet<IsOrtagi> IsOrtagis { get; set; }
        public DbSet<RiskAnalizi> RiskAnalizis { get; set; }
        public DbSet<Sirket> Sirkets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //bu kısımda tenantid ile iş ortağı bazlı benzersiz olması için kullandım.
            base.OnModelCreating(modelBuilder);
             
            var tenantId = _tenant.GetTenantId();

            modelBuilder.Entity<Sirket>().HasQueryFilter(e => e.TenantId == tenantId);
            modelBuilder.Entity<Anlasma>().HasQueryFilter(e => e.TenantId == tenantId);
            modelBuilder.Entity<AnlasmaIl>().HasQueryFilter(e => e.TenantId == tenantId);
            modelBuilder.Entity<AnlasmaKonulari>().HasQueryFilter(e => e.TenantId == tenantId);
            modelBuilder.Entity<RiskAnalizi>().HasQueryFilter(e => e.TenantId == tenantId);
            modelBuilder.Entity<IsOrtagi>().HasQueryFilter(e => e.TenantId == tenantId);
            modelBuilder.Entity<IsKonu>().HasQueryFilter(e => e.TenantId == tenantId);
            modelBuilder.Entity<IlAd>().HasQueryFilter(e => e.TenantId == tenantId);
        }
    }
}
