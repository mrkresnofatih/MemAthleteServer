using System.ComponentModel.DataAnnotations;

namespace MemAthleteServer.Models
{
    public class Player
    {
        public string PlayerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int YearOfBirth { get; set; }
    }

    public class PlayerLoginDto
    {
        [Required] public string PlayerId { get; set; }

        [Required] public string Password { get; set; }
    }

    public class PlayerCreateUpdateDto
    {
        [Required] [StringLength(20)] public string Username { get; set; }

        [Required] public string Password { get; set; }

        [Required] [StringLength(40)] public string Fullname { get; set; }

        [Required] [Range(1990, 2010)] public int YearOfBirth { get; set; }
    }
}