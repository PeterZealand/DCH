using DCH.Interfaces;
using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCH.Pages.Actors
{
    public class UpdateActorsModel : PageModel
    {
        private IActorRepository catalog;

        [BindProperty]
        public Actor Actor { get; set; }

        public UpdateActorsModel(IActorRepository cat)
        {
            catalog = cat;
        }

        public void OnGet(int id)
        {
            Actor = catalog.GetActors(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            catalog.UpdateActor(Actor);
            return RedirectToPage("GetAllActors");
        }
    }
}
