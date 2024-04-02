using Microsoft.EntityFrameworkCore;

// Make a reference of Data class
using ProyectoClase.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add my own MySql service
builder.Services.AddDbContext<LibraryUsersContext> (options =>
        {
            options.UseMySql (
                // builder.Configuration.GetConnectionString("<ALIAS>"),
                builder.Configuration.GetConnectionString("MySqlConnection"),
                // Microsoft.EntityFrameworkCore.ServerVersion.Parse("<Database version>")
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
            );
        }
    );

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
