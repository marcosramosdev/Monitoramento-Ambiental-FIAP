using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbiental.Data;
using MonitoramentoAmbiental.Data.Repositories;
using MonitoramentoAmbiental.Data.Repository;
using MonitoramentoAmbiental.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IParqueService, ParqueService>();
builder.Services.AddScoped<IParqueRepository, ParqueRepository>(); 


builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
