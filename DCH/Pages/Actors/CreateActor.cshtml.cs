using DCH.Interfaces;
using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCH.Pages.Actors
{
    public class CreateActorsModel : PageModel
    {
        private IActorRepository catalog;
        [BindProperty]
        public Actor Actor { get; set; }

        public CreateActorsModel(IActorRepository cat)
        {
            catalog = cat;
        }


        public IActionResult OnGet(int id)
        {
            Actor = new Actor();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Actor.Id == 0)
            {
                catalog.AddActor(Actor);
            }
            return RedirectToPage("GetAllActors");
        }
    
    //public void OnGet()
    //    {
    //    }
    }
}
