using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TestyMatematyczne.Services.Datapacks
{
    public class Question
    {
        [Required]
        [Display(Name = "Pytanie")]
        public string task { get; set; }

        [Display(Name = "Podpowiedzi")]
        public string? hint { get; set; }
        [Required]
        [Display(Name = "Odpowiedź")]
        public int answer { get; set; }
    }
}
