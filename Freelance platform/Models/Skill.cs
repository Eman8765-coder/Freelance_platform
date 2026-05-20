namespace Freelance_Platform.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public int FreelancerId { get; set; }
        public string SkillName { get; set; } = string.Empty;
    }
}