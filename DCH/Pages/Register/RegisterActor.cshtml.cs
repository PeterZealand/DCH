using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCH.Pages.Register
{
    public class RegisterActorModel : PageModel
    {
        public Actor Actor { get; set; }
        public Event Event { get; set; }



        public void OnGet()
        {

        }
    }
}
