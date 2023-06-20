using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestyMatematyczne.Pages
{
    public class KokpitModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public KokpitModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
