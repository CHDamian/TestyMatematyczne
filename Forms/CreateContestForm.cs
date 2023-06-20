using System.ComponentModel.DataAnnotations;

namespace TestyMatematyczne.Forms
{
	public class CreateContestForm
	{
		[Required]
        [Display(Name = "Nazwa")]
        [MaxLength(30, ErrorMessage = "Max {1} znaków")]
		public string Name { get; set; }
        [Required]
        [Display(Name = "Poziom trudności")]
        public string Difficulty { get; set; }
    }
}
