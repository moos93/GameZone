using GameZone.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace GameZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        
        public HomeController( ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }
   
            public IActionResult Index()
            {
          
                return View();
            }


            public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
