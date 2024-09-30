using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
    }
}



