using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TestyMatematyczne.Services.Datapacks;

namespace TestyMatematyczne.ViewModels
{
    public class TestToModify
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Poziom")]
        public string Difficulty { get; set; }
        [Required]
        public List<String> Questions { get; set; }

        public bool IsSameUser { get; set; }

    }
}
