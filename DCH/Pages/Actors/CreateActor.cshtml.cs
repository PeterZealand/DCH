using DCH.Interfaces;
using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DCH.Pages.Actors
{
    public class CreateActorsModel : PageModel
    {
        private IActorRepository catalog;
        [BindProperty]
        public Actor Actor { get; set; }

        public bool IsSuccessful { get; set; }
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
        public IActionResult OnPostUser()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Actor.Id == 0)
            {
                catalog.AddActor(Actor);
            }
            return RedirectToPage("OpretBrugerSuccess");
            IsSuccessful = true; // S�tter indikatoren til true ved succesfuld oprettelse
            return Page();
        }

    }
}
