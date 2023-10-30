using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ProjectTravel.Models;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


///scaffold - DbContext "data source=LAPTOP-MNHTN2HS\SQLEXPRESS;initial catalog=TravelDB;integrated security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models
///scaffold - DbContext "data source=LAPTOP-MNHTN2HS\SQLEXPRESS;initial catalog=TravelDB;integrated security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models -force
