using System.ComponentModel.DataAnnotations;

namespace TestyMatematyczne.ViewModels
{
    public class RankedUser
    {
        [Display(Name = "Pozycja")]
        public int Position { get; set; }
        [Display(Name = "Użytkownik")]
        public string UserName { get; set; }
        [Display(Name = "Punkty")]
        public int Points { get; set; }
    }
}
