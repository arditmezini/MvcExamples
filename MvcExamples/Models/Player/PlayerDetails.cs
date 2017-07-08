using System.ComponentModel.DataAnnotations;
using MvcExamples.Models.Wizard;

namespace MvcExamples.Models.Player
{
    public class PlayerDetails : StepModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [StringLength(100)]
        public string Nationality { get; set; }
    }
}