using System.ComponentModel.DataAnnotations;

namespace MvcExamples.Models.Player
{
    public class PlayerSummary
    {
        [Required]
        public PlayerDetails PlayerDetails { get; set; }
        [Required]
        public PlayerStatistics PlayerStatistics { get; set; }
    }
}