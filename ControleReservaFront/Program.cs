using ControleReserva.Application.Service;
using ControleReserva.Domain.Interface.HttpClient;
using ControleReserva.Domain.Interface.Service;
using ControleReserve.Infraestructure.ClientHttp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IReservaService, ReservaService>();
builder.Services.AddScoped<IReservaHttpClient, ReservaHttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Reserva}/{action=Index}/{id?}");

app.Run();
