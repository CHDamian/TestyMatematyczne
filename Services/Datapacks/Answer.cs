using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TestyMatematyczne.Services.Datapacks
{
    public class Answer
    {
        [Required]
        [Display(Name = "Odpowiedź")]
        public int userAnswer { get; set; }
        public bool isCorrect { get; set; }
    }
}
