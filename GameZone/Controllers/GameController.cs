
using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GameZone.Controllers
{
    
    public class GameController : Controller
    {
        private readonly ManageApi _manageApi;
        public GameController(ManageApi manageApi)
        {
            _manageApi = manageApi;
        }
        public async Task<IActionResult> Index()
        {
            var games = await _manageApi.GetAsync<List<Game>>("https://localhost:7064/api/Game");
            return View(games);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var game = await _manageApi.GetAsync<Game>($"https://localhost:7064/api/Game/{id}");
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                bool success = await _manageApi.PutAsync($"https://localhost:7064/api/Game/{id}", game);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(game);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var game = await _manageApi.GetAsync<Game>($"https://localhost:7064/api/Game/{id}");
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool success = await _manageApi.DeleteAsync($"https://localhost:7064/api/Game/{id}");
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game game)
        {
            if (ModelState.IsValid)
            {
                bool success = await _manageApi.PostAsync("https://localhost:7064/api/Game", game);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Error creating the game.");
                }
            }
            return View(game);
        }


        public async Task<IActionResult> Details(int id)
        {
            var game = await _manageApi.GetAsync<Game>($"https://localhost:7064/api/Game/{id}");
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

    }
}
//public class GameController : Controller
//{
//    private readonly string Baseurl = "https://localhost:7064/";
//    public GameController()
//    {

//    }
//    public async Task<IActionResult> Index()
//    {
//        List<Game> games = new List<Game>();
//        try
//        {

//            var _game = await ManageAPI.GetGameAPI("api/Game/GetAll");
//            if (!string.IsNullOrEmpty(_game))
//            {
//                games = JsonConvert.DeserializeObject<List<Game>>(_game);

//            }

//            //returning the employee list to view
//            // return View(EmpInfo);
//            return View(games); // Pass the games list to the view



//            // Call the API to get the list of games
//            // var games = await _httpClient.GetFromJsonAsync<List<Game>>("game");
//        }
//        catch (HttpRequestException ex)
//        {
//            // Handle network or API errors
//            ViewBag.ErrorMessage = "Error accessing API: " + ex.Message;
//            return View("Error");

//        }
//    }
//    public async Task<IActionResult> Create()
//    {
//        var game = new Game();

//    }


//}

