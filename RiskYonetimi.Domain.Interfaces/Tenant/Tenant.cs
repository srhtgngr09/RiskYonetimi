namespace RiskYonetimi.Application.Tenant
{
    //Tenant id için interface i oluşturuldu. Application katmanından alamanın sebebi WebAPI ve EF katmanlarına bağımlı olamadığı için bu katmanda oluşturdum.
    public class Tenant:ITenant
    {
        private readonly IHttpContextAccessor _context;

        public Tenant(IHttpContextAccessor context)
        {
            _context = context;
        }

        public int GetTenantId()
        {
            var header = _context.HttpContext?.Request.Headers["X-Firma-Id"].FirstOrDefault();
            return int.TryParse(header, out var tenantId) ? tenantId : 0;
        }
    }
}
