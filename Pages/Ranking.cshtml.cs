using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestyMatematyczne.Interfaces;
using TestyMatematyczne.Services.Datapacks;
using TestyMatematyczne.ViewModels;

namespace TestyMatematyczne.Pages
{
    public class RankingModel : PageModel
    {
        private readonly IRankingService _rankingService;
        private readonly IConfiguration Configuration;

        public RankingModel(IRankingService rankingService, IConfiguration configuration)
        {
            _rankingService = rankingService;
            Configuration = configuration;
        }

        public PaginatedList<RankedUser> tests { get; set; }
        public async Task OnGetAsync(int? pageIndex)
        {
            List<RankedUser> test_list = _rankingService.GetRanking();

            var pageSize = Configuration.GetValue("PageSize", 20);
            tests = await PaginatedList<RankedUser>.CreateAsync(
                test_list, pageIndex ?? 1, pageSize);
        }
    }
}
