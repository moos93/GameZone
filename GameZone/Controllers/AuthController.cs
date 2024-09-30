using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace GameZone.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient httpClient;
        public AuthController(HttpClient _httpClient)
        {
            httpClient =_httpClient;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

            // Send request to GamersJwtApi to authenticate
            var response = await httpClient.PostAsync("https://localhost:7127/login", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(result);

                // Store the token in session
                HttpContext.Session.SetString("JWTToken", tokenResponse.Token);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var content = new StringContent(JsonConvert.SerializeObject(registerRequest), Encoding.UTF8, "application/json");

            // Send request to GamersJwtApi to register
            var response = await httpClient.PostAsync("https://localhost:7127/register", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }

            ModelState.AddModelError(string.Empty, "Registration failed.");
            return View();
        }
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class RegisterRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
        }

        public class TokenResponse
        {
            public string Token { get; set; }
        }
    }
}
