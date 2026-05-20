namespace Freelance_Platform.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ContractId { get; set; }
        public int Rating { get; set; }   // 1 to 5
        public string Feedback { get; set; } = string.Empty;
        public string ReviewDate { get; set; } = string.Empty;

        // For display
        public string ProjectTitle { get; set; } = string.Empty;
        public string FreelancerName { get; set; } = string.Empty;
    }
}
