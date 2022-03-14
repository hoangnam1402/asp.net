using BackEnd.Model;
using Identity.Data;
using IdentityServer4;
using IdentityServer4.AspNetIdentity;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

string AllOrigins = "AllowAllOrigins";

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;
var defaultConnString = "Server=DESKTOP-8I3DA26;Database=dotnet-test;Trusted_Connection=True";

builder.Services.AddDbContext<AspNetIdentityDbContext>(options =>
{

    options.UseSqlServer(defaultConnString,
        b => b.MigrationsAssembly(migrationsAssembly));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}
            );

builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<AspNetIdentityDbContext>()
.AddDefaultTokenProviders();

// configure identity server with sqlserver stores, keys, clients and scopes
builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
})
.AddAspNetIdentity<User>()
.AddConfigurationStore(options =>
{
    options.ConfigureDbContext = b =>
    b.UseSqlServer(defaultConnString, opt => opt.MigrationsAssembly(migrationsAssembly));
})
.AddOperationalStore(options =>
{
    options.ConfigureDbContext = b =>
    b.UseSqlServer(defaultConnString, opt => opt.MigrationsAssembly(migrationsAssembly));
});

builder.AddDeveloperSigningCredential();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseCors(AllOrigins);
app.UseIdentityServer();

app.Run();