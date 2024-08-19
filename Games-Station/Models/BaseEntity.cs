

using System.ComponentModel.DataAnnotations;

namespace GamesStudio.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;

    }
}
