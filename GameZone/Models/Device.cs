using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Device
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Generation { get; set; }
        public List<Game> Games { get; set; }
    }
}

