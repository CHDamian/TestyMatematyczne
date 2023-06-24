using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System;
using TestyMatematyczne.Interfaces;
using TestyMatematyczne.ViewModels;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using TestyMatematyczne.Services.Datapacks;

namespace TestyMatematyczne.Pages
{
    public class RaportTestuModel : PageModel
    {
        private readonly IUserService _userService;

        public RaportTestuModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public TestRaport raport { get; set; }

        public async Task<IActionResult> OnGetAsync(int cid, string uid, string date, bool? saveChangesError = false)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("./Index");
            }
            raport = _userService.GetTestRaport(cid, uid, DateTime.Parse(date));

            return Page();
        }
    }
}
