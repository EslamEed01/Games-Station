
using Games_Station.Models;
using System.ComponentModel.DataAnnotations;

namespace GamesStudio.Models
{
    public class Game : BaseEntity
    {
        // string is required by default begin with .net 6


        [MaxLength(3000)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Cover { get; set; } = string.Empty;


        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();

    }
}
