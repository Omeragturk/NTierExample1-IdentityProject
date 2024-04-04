using Microsoft.AspNetCore.Identity;
using NTierExample.Entities.AppIdentityEntities;
using TierExample.DAL.Contexts.AppIdentityContext;
using TierExample.DAL.ServiceExtension;
using NTierExample.BLL.ServiceExtension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDalServices()
                .AddBllServices();

builder.Services.AddIdentity<AppUser, AppRole>(_ =>
{
    _.Password.RequiredLength = 4;
    _.Password.RequireNonAlphanumeric = false;
    _.Password.RequireLowercase = false;
    _.Password.RequireUppercase = false;
    _.Password.RequireDigit = false;

    _.User.RequireUniqueEmail = true;
    _.User.AllowedUserNameCharacters = "qwertyuýopðüasdfghjklþizxcvbnmöçQWERTYUIOPÐÜÝÞLKJHGFDSAZXCVBNMÖÇ0123456789!&-_*+.";
}).AddEntityFrameworkStores<AppIdentityDbContext>()
  .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(_ =>
{
    _.LoginPath = new PathString("/Home/Index");
    _.LogoutPath = new PathString("/Home/Logout");
    _.Cookie = new CookieBuilder
    {
        Name = "AspNetCoreIdentityCookie",
        HttpOnly = false,
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.None,
    };

    _.SlidingExpiration = true;
    _.ExpireTimeSpan = TimeSpan.FromDays(1);
    _.AccessDeniedPath = new PathString("/Home/Index");
});

builder.Services.AddSession();

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

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});



app.Run();
