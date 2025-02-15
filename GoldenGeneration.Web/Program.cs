using GoldenGeneration.Infrastructure;
using GoldenGeneration.Services.Implementations;
using GoldenGeneration.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static GoldenGeneration.Infrastructure.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<GoldenGenerationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<GoldenGenerationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication();

builder.Services.AddAuthorization(options =>
{
    string[] roles = [Admin];
    foreach (var role in roles)
    {
        options.AddPolicy(role, policy => policy.RequireRole(role));
    }
});

builder.Services.AddScoped<IFootballerService, FootballerService>();
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<IKitService, KitService>();
builder.Services.AddScoped<ILeagueService, LeagueService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IPositionService, PositionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.MapRazorPages();

app.Run();
