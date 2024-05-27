using DCH.Interfaces;
using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Text.RegularExpressions;

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

            
            if (CheckIfActorExists(Actor.Email) == true)
            {
                // email adressen findes i listen og derfor sendes brugeren tilbage for at oprette sig med en anden email adresse
                //TODO vi skal ha ændret koden så den giver en fejl i stedet for at sende en tilbage til create actor
                return RedirectToPage("CreateActor");
            }
            else 
            {   
                // email adressen findes ikke på medlemslisten og derfor bliver medlemet oprettet i systemet og sendes videre til login siden.
                catalog.AddActor(Actor);        
                return RedirectToPage("ActorLogin");
            }
    
            // Medlemmer må ikke tilgå admin siden med alle medlemmer.
            //return RedirectToPage("GetAllActors");
        }

        
        private bool CheckIfActorExists(string email)
        {
            var actors = catalog.AllActors();
            
            // tjek om der eksisterer et medlem med email adressen, som brugeren ønsker at oprette sig med.
            return actors.Values.Any(a =>
            a.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
