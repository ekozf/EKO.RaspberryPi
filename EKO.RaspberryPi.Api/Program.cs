using EKO.RaspberryPi.Api.Services;
using EKO.RaspberryPi.Api.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IServerDetailsService, ServerDetailsService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
