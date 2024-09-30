
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using GameZone.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GameZone.Controllers;


var builder = WebApplication.CreateBuilder(args);
// Configure JWT Authentication
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = "GamersJwtApiIssuer", 
//        ValidAudience = "GameZoneAudience", 
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTcyNzYwODgyNywiaWF0IjoxNzI3NjA4ODI3fQ.YnF1D4anPR_OGyo9yCIBm3K_LcvjrNdNZ6_-QvqwYdU")) // Set according to your Identity API
//    };
//});

//// Add session to store tokens
//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(60); 
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc().
    AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).
    AddDataAnnotationsLocalization();
builder.Services.AddControllersWithViews();

        builder.Services.AddHttpClient();
        builder.Services.AddScoped<ManageApi>();
//builder.Services.AddSingleton<AuthController>();
        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[]
            {
        new CultureInfo("en"),
        new CultureInfo("ar")
            };
            options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        var locOption = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(locOption.Value);

        app.UseAuthorization();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");


        app.Run();
