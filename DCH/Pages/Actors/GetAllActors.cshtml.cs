using DCH.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCH.Pages.Actors
{
    public class GetAllActorsModel : PageModel
    {
        private IActorRepository catalog;  

        public GetAllActorsModel(IActorRepository cat)
        {
            catalog = cat;
        }

        public Dictionary<int, @DCH.Models.Actor> actors { get; private set; }
        public IActionResult OnGet()
        {
            actors = catalog.AllActors();
            return Page();
        }
    }
}
