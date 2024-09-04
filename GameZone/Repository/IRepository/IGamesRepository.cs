using GameZone.Models;

namespace GameZone.Repository.IRepository
{
    public interface IGamesRepository :IRepository<Game>
    {
        void Update(Game obj);
        void Save();
    }
}
