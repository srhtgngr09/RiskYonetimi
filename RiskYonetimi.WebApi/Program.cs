using Microsoft.EntityFrameworkCore;
using RiskYonetimi.Application.FirmaBilgiAlService;
using RiskYonetimi.Application.Tenant;
using RiskYonetimi.EF.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IFirmaBilgileriAlService, FirmaBilgileriAlService>();
builder.Services.AddScoped<ITenant, Tenant>();
builder.Services.AddControllers();
builder.Services.AddAuthorization(); // ? Bunu ekle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


app.MapGet("/", () => "Hello World!");
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();




app.UseSwagger();
app.UseSwaggerUI();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//app.UseSwagger();
//app.UseSwaggerUI();
