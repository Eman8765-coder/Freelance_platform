namespace Freelance_Platform.Models
{
    public class Bid
    {
        public int BidId { get; set; }
        public int ProjectId { get; set; }
        public int FreelancerId { get; set; }
        public double BidAmount { get; set; }
        public string Proposal { get; set; } = string.Empty;
        public string BidDate { get; set; } = string.Empty;

        // For display
        public string FreelancerName { get; set; } = string.Empty;
        public string ProjectTitle { get; set; } = string.Empty;
    }
}