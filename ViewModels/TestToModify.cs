using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TestyMatematyczne.Services.Datapacks;

namespace TestyMatematyczne.ViewModels
{
    public class TestToModify
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Poziom")]
        public string Difficulty { get; set; }
        public List<String> Questions { get; set; }

        public bool IsSameUser { get; set; }

    }
}
