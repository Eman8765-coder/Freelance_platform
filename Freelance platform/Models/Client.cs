namespace Freelance_Platform.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; } = string.Empty;

        // For display — loaded by joining with Users table
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}