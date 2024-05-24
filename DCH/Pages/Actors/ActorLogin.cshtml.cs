using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DCH.Models;
using DCH.Interfaces;

namespace DCH.Pages.Actors
{
    public class ActorLoginModel : PageModel
    {
        [BindProperty]
        public Actor actor { get; set; }

        public string ErrorMessage { get; set; }

        private IActorRepository catalog;

        public ActorLoginModel(IActorRepository actorRepository)
        {
            catalog = actorRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (CheckCredentials(actor.Email, actor.Password))
            {
                return RedirectToPage("/Events/ReadOnlyEvents");
            }
            else
            {
                ErrorMessage = "Invalid username or password";
                return Page();
            }
        }

        private bool CheckCredentials(string email, string password)
        {
            var actors = catalog.AllActors();

            //checker om email og password eksisterer
            // => This is a lambda expression representing the condition to be checked for each Actor object in the collection.
            //'a' represents each Actor object in the actors.Values collection.
            return actors.Values.Any(a =>
                a.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                a.Password.Equals(password));
        }
    }
}
