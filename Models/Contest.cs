using System.ComponentModel.DataAnnotations;

namespace TestyMatematyczne.Models
{
    public class Contest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }
        public User Organizer { get; set; }
        [Required]
        [Range(1, 3)]
        public int Difficulty { get; set; }
        [Required]
        public string Questions { get; set; }

        [Required]
        public bool Published { get; set; }

        public ICollection<Solution>? Solution { get; set; }
    }
}
