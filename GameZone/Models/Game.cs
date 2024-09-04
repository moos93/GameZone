using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        [DisplayName("Game Name")]
        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters.")]
        public string? Name { get; set; }
        [Required, MaxLength(30)]
        [DisplayName("Game Description")]
        public string? Description { get; set; }
        [Required, MaxLength(30)]
        [DisplayName("Game Level")]
        public string? Level { get; set; }
    }
}



