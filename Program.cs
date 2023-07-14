using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BusTicketBooking.DataAccess;
using BusTicketBooking.Models;
using BusTicketBooking.DataAccess.Repositories;
using System.Configuration;
using BusTicketBooking.DataAccess.Infrastructure;
using BusTicketBooking.Utlities;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddControllersWithViews();

var app = builder.Build();
DataSeeding();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Admin}/{controller=Bus}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
void DataSeeding()
{
    using (var scope = app.Services.CreateScope())
    {
        var DbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        DbInitializer.Initialize();
    }
}
