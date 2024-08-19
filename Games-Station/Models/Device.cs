

using System.ComponentModel.DataAnnotations;

namespace GamesStudio.Models
{
    public class Device : BaseEntity
    {
        [MaxLength(50)]
        public string Icon { get; set; } = string.Empty;
    }
}
