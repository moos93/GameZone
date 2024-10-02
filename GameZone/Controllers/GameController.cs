
using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GameZone.Controllers
{
    public class GameController : Controller
    {
        private readonly ManageApi _manageApi;
        private readonly string _baseUrl;

        public GameController(ManageApi manageApi, IConfiguration config)
        {
            _manageApi = manageApi;
            _baseUrl = config.GetSection("ApiSettings")["BaseUrl"]; // Fetch the baseUrl from appsettings.json
        }

        // GET: Get all games
        public async Task<IActionResult> Index()
        {
            var games = await _manageApi.GetAllGamesAsync(_baseUrl);
            return View(games);
        }

        // GET: Get game by ID
        public async Task<IActionResult> Details(int id)
        {
            var game = await _manageApi.GetGameByIdAsync(id, _baseUrl);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // GET: Create game view
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create game
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Game game)
        {
            if (ModelState.IsValid)
            {
                var response = await _manageApi.CreateGameAsync(game, _baseUrl);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(game);
        }

        // GET: Edit game view
        public async Task<IActionResult> Edit(int id)
        {
            var game = await _manageApi.GetGameByIdAsync(id, _baseUrl);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Edit game
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Game game)
        {
            if (id != game.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var success = await _manageApi.EditGameAsync(id, game, _baseUrl);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Delete confirmation view
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _manageApi.GetGameByIdAsync(id, _baseUrl);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Delete game
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _manageApi.DeleteGameAsync(id, _baseUrl);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }

}
//    public class GameController : Controller
//    {
//        private readonly ManageApi _manageApi;
//        private readonly string _baseUrl;
//        public GameController(ManageApi manageApi, IConfiguration config)
//        {
//            _manageApi = manageApi;
//            _baseUrl = config.GetSection("ApiSettings")["BaseUrl"];
//        }
//        public async Task<IActionResult> Index()
//        {
//            var games = await _manageApi.GetAsync<List<Game>>(_baseUrl);
//            return View(games);
//        }

//        public async Task<IActionResult> Edit(int id)
//        {
//            var game = await _manageApi.GetAsync<Game>(_baseUrl);
//            if (game == null)
//            {
//                return NotFound();
//            }
//            return View(game);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit(int id, Game game)
//        {
//            if (id != game.Id)
//            {
//                return BadRequest();
//            }

//            if (ModelState.IsValid)
//            {
//                bool success = await _manageApi.PutAsync(_baseUrl, game);
//                if (success)
//                {
//                    return RedirectToAction(nameof(Index));
//                }
//            }
//            return View(game);
//        }

//        public async Task<IActionResult> Delete(int id)
//        {
//            var game = await _manageApi.GetAsync<Game>(_baseUrl);
//            if (game == null)
//            {
//                return NotFound();
//            }
//            return View(game);
//        }

//        [HttpPost, ActionName("Delete")]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            bool success = await _manageApi.DeleteAsync(_baseUrl);
//            if (success)
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            return View();
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(Game game)
//        {
//            if (ModelState.IsValid)
//            {
//                bool success = await _manageApi.PostAsync(_baseUrl, game);
//                if (success)
//                {
//                    return RedirectToAction(nameof(Index));
//                }
//                else
//                {
//                    ModelState.AddModelError("", "Error creating the game.");
//                }
//            }
//            return View(game);
//        }


//        public async Task<IActionResult> Details(int id)
//        {
//            var game = await _manageApi.GetAsync<Game>(_baseUrl);
//            if (game == null)
//            {
//                return NotFound();
//            }
//            return View(game);
//        }

//    }
//}