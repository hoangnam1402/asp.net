using BackEnd.Data;
using ClassLibrary;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDataAccessorLayer(builder.Configuration);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
   builder.Configuration.GetConnectionString("DbConnection")
));

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
.AddCookie("Cookies", options =>
{
    options.AccessDeniedPath = "/Errors/Error403";
})
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = "https://localhost:5005";

    options.ClientId = "interactive";
    options.ClientSecret = "ClientSecret1";
    options.ResponseType = "code";
    options.UsePkce = true;

    options.Scope.Add("profile");
    options.Scope.Add("offline_access");

    options.GetClaimsFromUserInfoEndpoint = true;
    options.SaveTokens = true;
});

builder.Services.AddIdentityLayer(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
