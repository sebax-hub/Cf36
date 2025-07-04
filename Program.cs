using Microsoft.EntityFrameworkCore;
using Cf36.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Para la base de datos
builder.Services.AddDbContext<Cf36Context>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("ConexionDb"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.25-mariadb")));
// Fin para la base de datos

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

app.Run();
