using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestyMatematyczne.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using TestyMatematyczne.Services;
using TestyMatematyczne.ViewModels;
using TestyMatematyczne.Services.Datapacks;
using Newtonsoft.Json;

namespace TestyMatematyczne.Pages
{
    public class RozwiazTestModel : PageModel
    {
        private readonly IUserService _userService;

        public RozwiazTestModel(IUserService userService)
        {
            _userService = userService;
        }
		[BindProperty]
		public TestToSolve test { get; set; }
        [BindProperty]
        public List<Answer> answers { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError = false)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("./Index");
            }

            test = _userService.GetTestToSolve(id);
            answers = _userService.PrepareListOfAnswers(test.questions.Count);
            return Page();
        }

		public IActionResult OnPost()
		{
			var url = $"/RozwiazTest?id={test.id}";
            var date = _userService.SaveTestSolution(test.id, User.Identity.Name, answers);
            url = $"/RaportTestu?cid={test.id}&uid={User.Identity.Name}&date={date.ToString()}";
			return Redirect(url);
		}
	}
}
