using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestyMatematyczne.Interfaces;
using TestyMatematyczne.Services.Datapacks;
using TestyMatematyczne.ViewModels;

namespace TestyMatematyczne.Pages
{
    public class MojeRozwiazaniaModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IConfiguration Configuration;

        public MojeRozwiazaniaModel(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            Configuration = configuration;
        }
        public PaginatedList<UserSolution> tests { get; set; }
        public async Task OnGetAsync(int? pageIndex)
        {
            List<UserSolution> test_list = _userService.GetUserSolutions(User.Identity.Name);

            var pageSize = Configuration.GetValue("PageSize", 20);
            tests = await PaginatedList<UserSolution>.CreateAsync(
                test_list, pageIndex ?? 1, pageSize);
        }
    }
}
