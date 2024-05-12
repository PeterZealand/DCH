using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCH.Pages.Events
{
    public class CreateEventModel : PageModel
    {
        public Event Event { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
