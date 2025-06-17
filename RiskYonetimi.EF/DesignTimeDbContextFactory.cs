using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RiskYonetimi.EF.Data;

namespace RiskYonetimi.EF
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-OJ2LK0L\\MSSQLSERVER_SERH; Database=RiskYonetim; Trusted_Connection=True; TrustServerCertificate=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
