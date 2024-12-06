using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbiental.Data.Repositories;
using MonitoramentoAmbiental.Data.Repository;
using MonitoramentoAmbiental.Data;
using MonitoramentoAmbiental.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IParqueRepository, ParqueRepository>();
builder.Services.AddScoped<ICondicaoClimaticaRepository, CondicaoClimaticaRepository>();
builder.Services.AddScoped<IConfiguracaoIrrigacaoRepository, ConfiguracaoIrrigacaoRepository>();
builder.Services.AddScoped<IHistoricoIrrigacaoRepository, HistoricoIrrigacaoRepository>();
builder.Services.AddScoped<IRegraCondicaoClimaticaRepository, RegraCondicaoClimaticaRepository>();
builder.Services.AddScoped<IParqueService, ParqueService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
