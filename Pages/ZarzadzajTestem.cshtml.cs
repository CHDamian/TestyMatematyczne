using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestyMatematyczne.Interfaces;
using TestyMatematyczne.Services.Datapacks;
using TestyMatematyczne.ViewModels;

namespace TestyMatematyczne.Pages
{
    public class ZarzadzajTestemModel : PageModel
    {
        private readonly ITeacherService _teacherService;
        public ZarzadzajTestemModel(ITeacherService teacherService) 
        {
            _teacherService= teacherService;
        }

        [BindProperty]
        public TestToModify? test { get; set; }

        [BindProperty]
        public Question question { get; set; }
        public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError = false)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Teacher"))
            {
                return RedirectToPage("./Index");
            }

            test = _teacherService.GetTestToModify(id, User.Identity.Name);
            
            if(!test.IsSameUser) 
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var url = $"/ZarzadzajTestem?id={test.Id}";
            if (question.task == null)
            {
                return Redirect(url);
            }
            _teacherService.AddNewQuestionToTest(test.Id, question);
            return Redirect(url);
        }
    }
}
