using EX.Core.Interfaces;
using EX.Core.Services;
using EX.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbContext, EXContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPrestataireService, PrestataireService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ISpecialiteService, SpecialiteService>();
builder.Services.AddScoped< IPresationService,PresationService>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

//routes.MapControllerRoute(
//           name: "prestation",
//url: "prestation/{id}",
//           defaults: new { controller = "Prestataire", action = "Index", id = ""}
//       );
app.Run();
