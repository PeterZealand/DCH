using DCH.Interfaces;
using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCH.Pages.Actors
{
    public class DeleteActorModel : PageModel
    {
        [BindProperty]
        public Actor Actor { get; set; }

        private IActorRepository catalog;

        public DeleteActorModel(IActorRepository actorRepository)
        {
            catalog = actorRepository;
        }

        public IActionResult OnGet(int id)
        {
            Actor = catalog.GetActors(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            catalog.DeleteActor(id);
            return RedirectToPage("GetAllActors");
        }
    }
}
