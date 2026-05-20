namespace Freelance_Platform.Models
{
    public class Freelancer
    {
        public int FreelancerId { get; set; }
        public int UserId { get; set; }
        public string Experience { get; set; } = string.Empty;
        public double HourlyRate { get; set; }
        public double Rating { get; set; }

        // For display — loaded by joining with Users table
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}