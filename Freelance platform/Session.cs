using Freelance_Platform.Models;

namespace Freelance_Platform
{
    public static class Session
    {
        public static User? CurrentUser { get; set; }
        public static int ClientId { get; set; }
        public static int FreelancerId { get; set; }

        public static bool IsClient => CurrentUser?.Role == "client";
        public static bool IsFreelancer => CurrentUser?.Role == "freelancer";

        public static void Clear()
        {
            CurrentUser = null;
            ClientId = 0;
            FreelancerId = 0;
        }
    }
}