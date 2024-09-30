using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Drawing.Text;

namespace GameZone.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageController : ControllerBase
    {
        private readonly IStringLocalizer<LanguageController> _localizer;
        public LanguageController(IStringLocalizer<LanguageController> Localizer)
        {
            _localizer = Localizer;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var userName = "Mohamamd Mosbah";
            return Ok(_localizer["Welcome,"].Value + _localizer[userName].Value);
        }
    }
}
