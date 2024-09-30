//using Microsoft.EntityFrameworkCore;
//using GameZone.re.IRepository;
//using GameZone.Repository;
//using Microsoft.AspNetCore.Localization;
//using Microsoft.AspNetCore.Mvc.Razor;
//using System.Globalization;
//using GameZone.DataAccess;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddHttpClient();

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddScoped<IGamesRepository, GameRepository>();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
//builder.Services.AddMvc().
//    AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).
//    AddDataAnnotationsLocalization();
//builder.Services.AddControllersWithViews();
//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    var supportedCultures = new[]
//    {
//        new CultureInfo("en"),
//        new CultureInfo("ar")
//    };
//    options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
//    options.SupportedCultures = supportedCultures;
//    options.SupportedUICultures = supportedCultures;
//});

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


//app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

//app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
