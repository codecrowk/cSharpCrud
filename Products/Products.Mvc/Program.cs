using Microsoft.EntityFrameworkCore;
using Products.Mvc.Data;
using Products.Mvc.Helpers;
using Products.Mvc.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Personal service
builder.Services.AddDbContext<BaseContext> ( options => 
    options.UseMySql
    (
        // builder.Configuration.GetConnectionString("CONNECTION NAME"),

        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
    )
);

// Service for Helper and Provider
builder.Services.AddSingleton<HelperUploadFiles>();
builder.Services.AddSingleton<PathProvider>();

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
