using GameZone.DataAccess;
using GameZone.Models;
using GameZone.Repository.IRepository;

namespace GameZone.Repository
{
    public class GameRepository : Repository<Game>, IGamesRepository
    {
        private readonly ApplicationDbContext _db;
        public GameRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Game obj)
        {
            _db.Games.Update(obj);
        }
    }
}
