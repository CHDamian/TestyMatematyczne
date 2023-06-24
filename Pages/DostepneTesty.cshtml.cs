using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestyMatematyczne.Interfaces;
using TestyMatematyczne.Services.Datapacks;
using TestyMatematyczne.Services;
using TestyMatematyczne.ViewModels;

namespace TestyMatematyczne.Pages
{
    public class DostepneTestyModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IConfiguration Configuration;

        public DostepneTestyModel(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            Configuration = configuration;
        }

        public PaginatedList<PublishedTests> tests { get; set; }
        public async Task OnGetAsync(int? pageIndex)
        {
            List<PublishedTests> test_list = _userService.GetPublishedTests();

            var pageSize = Configuration.GetValue("PageSize", 20);
            tests = await PaginatedList<PublishedTests>.CreateAsync(
                test_list, pageIndex ?? 1, pageSize);
        }
    }
}
