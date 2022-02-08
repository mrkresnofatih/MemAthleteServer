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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Club { get; set; }
        public string Position { get; set; }
        public int AnnualSalary { get; set; }
    }
}