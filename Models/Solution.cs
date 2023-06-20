using Microsoft.Build.Framework;

namespace TestyMatematyczne.Models
{
    public class Solution
    {
        public int ContestId { get; set; }
        public Contest Contest { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime SolutionTime { get; set; }

        [Required]
        public string Answers { get; set; }

        [Required]
        public int Score { get; set; }
    }
}
