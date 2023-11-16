using EKO.RaspberryPi.AppLogic;
using EKO.RaspberryPi.AppLogic.Services;
using EKO.RaspberryPi.AppLogic.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
{
    policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((_) => true)
        .AllowCredentials();
}));

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IServerDetailsService, ServerDetailsService>();
builder.Services.AddSingleton<IArticleHandler, ArticleHandler>();

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
