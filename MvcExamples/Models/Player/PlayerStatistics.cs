using System.ComponentModel.DataAnnotations;
using MvcExamples.Models.Wizard;

namespace MvcExamples.Models.Player
{
    public class PlayerStatistics : StepModel
    {
        [Required]
        public int Height { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public int ShirtNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; }

        [Required]
        [StringLength(50)]
        public string Team { get; set; }

        [Required]
        public int GoalScored { get; set; }
    }
}