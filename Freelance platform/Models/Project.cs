namespace Freelance_Platform.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int ClientId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Budget { get; set; }
        public string Deadline { get; set; } = string.Empty;
        public string Status { get; set; } = "open";   // open / in-progress / completed / closed

        // For display
        public string ClientName { get; set; } = string.Empty;
    }
}