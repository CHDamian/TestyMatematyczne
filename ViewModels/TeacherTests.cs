using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TestyMatematyczne.ViewModels
{
    public class TeacherTests
    {

        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Poziom")]
        public string Difficulty { get; set; }
        [Display(Name = "CzyOpublikowane")]
        public bool Published { get; set; }

        public int numberOfTests { get; set; }
    }
}
