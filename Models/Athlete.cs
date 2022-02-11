using System.ComponentModel.DataAnnotations;

namespace MemAthleteServer.Models
{
    public class Athlete
    {
        public string AthleteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Club { get; set; }
        public string Position { get; set; }
        public int AnnualSalary { get; set; }
    }

    public class AthleteCreateUpdateDto
    {
        [Required] [StringLength(20)] public string FirstName { get; set; }

        [Required] [StringLength(20)] public string LastName { get; set; }

        [Required] [StringLength(50)] public string Club { get; set; }

        [Required] [StringLength(10)] public string Position { get; set; }

        [Required] [Range(1000, 10000)] public int AnnualSalary { get; set; }
    }
}