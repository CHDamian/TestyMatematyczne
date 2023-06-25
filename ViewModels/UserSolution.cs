using System.ComponentModel.DataAnnotations;

namespace TestyMatematyczne.ViewModels
{
    public class UserSolution
    {
        [Display(Name = "Nazwa Testu")]
        public string Name { get; set; }
        [Display(Name = "Rozwiązano")]
        public DateTime SolutionDate { get; set; }
        [Display(Name = "Punkty")]
        public int Points { get; set; }
        public int ContestId { get; set; }

    }
}
