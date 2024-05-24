using DCH.Interfaces;
using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DCH.Pages.Actors
{
    //public class CreateActorsModel : PageModel
    //{
    //    private IActorRepository catalog;
    //    [BindProperty]
    //    public Actor Actor { get; set; }

    //    public CreateActorsModel(IActorRepository cat)
    //    {
    //        catalog = cat;
    //    }


    //    public IActionResult OnGet(int id)
    //    {
    //        Actor = new Actor();
    //        return Page();
    //    }

    //    public IActionResult OnPost()
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return Page();
    //        }
    //        if (Actor.Id == 0)
    //        {
    //            catalog.AddActor(Actor);
    //        }
    //        return RedirectToPage("GetAllActors");
    //    }


    //}
    public class CreateActorsModel : PageModel
    {
        private IActorRepository catalog;

        [BindProperty]
        public Actor Actor { get; set; }

        public string Message { get; set; }

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

            long parsedPhoneNumber;
            bool isNumber = long.TryParse(Actor.PhoneNumber, out parsedPhoneNumber);

            if (!isNumber)
            {
                ModelState.AddModelError("Actor.PhoneNumber", "Indtast venligst et gyldigt telefonnummer.");
                return Page();
            }

            if (Actor.Id == 0)
            {
                catalog.AddActor(Actor);
            }

            Message = $"Telefonnummeret er gyldigt: {parsedPhoneNumber}";

            return RedirectToPage("GetAllActors");
        }
        public class NumericOnlyAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    var strValue = value.ToString();
                    if (!Regex.IsMatch(strValue, @"^\d+$"))
                    {
                        return new ValidationResult("Indtast venligst kun tal for telefonnummer.");
                    }
                }
                return ValidationResult.Success;
            }
        }
    }
}
