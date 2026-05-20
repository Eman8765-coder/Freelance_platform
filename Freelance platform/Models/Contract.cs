namespace Freelance_Platform.Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public int ProjectId { get; set; }
        public int FreelancerId { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public string Status { get; set; } = "active";   // active / completed / cancelled

        // For display
        public string ProjectTitle { get; set; } = string.Empty;
        public string FreelancerName { get; set; } = string.Empty;
    }
}