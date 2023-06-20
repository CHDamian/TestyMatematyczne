using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using TestyMatematyczne.Interfaces;
using TestyMatematyczne.Services.Datapacks;
using TestyMatematyczne.ViewModels;

namespace TestyMatematyczne.Pages
{
    public class Testy_NauczycielaModel : PageModel
    {
        private readonly ITeacherService _teacherService;
        private readonly IConfiguration Configuration;


        public Testy_NauczycielaModel(ITeacherService teacherService, IConfiguration configuration)
        {
            _teacherService= teacherService;
            Configuration = configuration;
        }

		public string Message { get; set; }
        public PaginatedList<TeacherTests> tests { get; set; }
        public async Task OnGetAsync(int? pageIndex)
        {
            List<TeacherTests> test_list = _teacherService.getTeacherTests(User.Identity.Name);

            var pageSize = Configuration.GetValue("PageSize", 20);
            tests = await PaginatedList<TeacherTests>.CreateAsync(
                test_list, pageIndex ?? 1, pageSize);
        }
    }
}
