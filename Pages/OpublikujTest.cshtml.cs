using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestyMatematyczne.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace TestyMatematyczne.Pages
{
    public class OpublikujTestModel : PageModel
    {
        private readonly ITeacherService _teacherService;
        public OpublikujTestModel(ITeacherService teacherService) 
        {
            _teacherService= teacherService;
        }
        public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError = false)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Teacher"))
            {
                return RedirectToPage("./Index");
            }

            _teacherService.PublishTest(id, User.Identity.Name);

            return RedirectToPage("./Testy_Nauczyciela");
        }
    }
}
