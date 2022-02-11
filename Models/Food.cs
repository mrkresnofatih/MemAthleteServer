using System.ComponentModel.DataAnnotations;

namespace MemAthleteServer.Models
{
    public class Food
    {
        public string FoodId { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public bool IsSnack { get; set; }
    }

    public class FoodCreateUpdateDto
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        
        [Required]
        [Range(50, 500)]
        public int Calories { get; set; }
        
        [Required]
        public bool IsSnack { get; set; }
    }
}