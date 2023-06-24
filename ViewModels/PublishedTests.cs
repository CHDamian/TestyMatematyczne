using System.ComponentModel.DataAnnotations;

namespace TestyMatematyczne.ViewModels
{
    public class PublishedTests
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Difficulty { get; set; }

    }
}
