namespace Freelance_Platform.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;  // "client" or "freelancer"
        public bool IsActive { get; set; } = true;

        // Extra fields used during registration only (not stored in Users table)
        public string? CompanyName { get; set; }   // for clients
        public string? Experience { get; set; }    // for freelancers
        public double HourlyRate { get; set; }     // for freelancers

        // Computed — no database column
        public string FullName => $"{FirstName} {LastName}";
    }
}