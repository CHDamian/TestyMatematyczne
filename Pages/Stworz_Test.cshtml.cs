using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestyMatematyczne.Forms;
using TestyMatematyczne.Interfaces;

namespace TestyMatematyczne.Pages
{
    public class Stworz_TestModel : PageModel
    {
		private readonly ITeacherService _teacherService;
		public Stworz_TestModel(ITeacherService teacherService) 
		{
			_teacherService= teacherService;
		}

        [BindProperty]
        public List<SelectListItem> difficultySelect { get; set; }

		[BindProperty]
		public CreateContestForm contestForm { get; set; }
        public IActionResult OnGet()
		{
			if (!User.Identity.IsAuthenticated || !User.IsInRole("Teacher"))
			{
				return RedirectToPage("./Index");
			}
			difficultySelect = _teacherService.GetDifficultyList();
			return Page();
		}

		public IActionResult OnPost()
		{
            if (!ModelState.IsValid)
            {
                return Page();
            }

			_teacherService.CreateNewContest(contestForm, User.Identity.Name);

            return RedirectToPage("/Testy_Nauczyciela");
		}

	}
}
