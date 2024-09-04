using GameZone.DataAccess;
using GameZone.Models;
using GameZone.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesRepository _gameRepo;
        public GamesController(IGamesRepository db)
        {
            _gameRepo = db;
        }
        public IActionResult Index()
        {
            List<Game> GameList = _gameRepo.GetAll().ToList();
            return View(GameList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Game obj)
        {
            if(ModelState.IsValid)
            {
                _gameRepo.Add(obj);
                _gameRepo.Save();
                return RedirectToAction("Index");
            }    
            return View();
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Game? GameFromDb = _gameRepo.Get(u=>u.Id==Id);
            if (GameFromDb == null)
            {
                return NotFound();
            }
            return View(GameFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Game Obj)
        {
            if (ModelState.IsValid)
            {
                _gameRepo.Update(Obj);
                _gameRepo.Save();
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Game? GameFromDb = _gameRepo.Get(u=>u.Id==Id);
            if (GameFromDb == null)
            {
                return NotFound();
            }
            return View(GameFromDb);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteGame(int? Id)
        {
            Game? obj = _gameRepo.Get(u => u.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            _gameRepo.Remove(obj);
            _gameRepo.Save();
            return RedirectToAction("Index");


        }
    }
}

