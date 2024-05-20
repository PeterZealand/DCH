using System.ComponentModel.DataAnnotations;

namespace DCH.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Navn på event er påkrævet og må max være 40 tegn."), MinLength(1), MaxLength(40)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Beskrivelse af din event er nødvendig og må maks være på 200 tegn"),
            MinLength(1), MaxLength(200),]
        public string Description { get; set; }

        public string City { get; set; }

        [Required(ErrorMessage = "DateTime is required")] //Dette er en indbygget valideringsattribut i .NET, der angiver, at DateTime-egenskaben er påkrævet, hvilket betyder, at den ikke kan være null. Hvis værdien er null, eller hvis feltet er tomt, vil denne valideringsattribut tilføje fejlmeddelelsen "DateTime is required"
        [CustomDateValidation(ErrorMessage = "Event datoen skal være fra d.d eller i fremtiden.")] // Dette er en brugerdefineret valideringsattribut, som du har oprettet, der specificerer yderligere valideringsregler for DateTime-egenskaben. I dette tilfælde kræver attributten, at DateTime skal være i dag eller i fremtiden. Hvis DateTime-værdien er i fortiden, returnerer denne valideringsattribut en fejlmeddelelse "Event datoen skal være fra d.d eller i fremtiden."
        public DateTime DateTime { get; set; } // Dette er en propertie til DateTime 

        public class CustomDateValidationAttribute : ValidationAttribute // CustomDateValidationAttribute er brugerdefineret valideringsattribut kaldet og ValidationAttribute er en indbygget attribut som bliver udvidet
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateTime dateValue)
                {
                    if (dateValue < DateTime.Today)
                    {
                        return new ValidationResult(ErrorMessage ?? "Event datoen skal være fra d.d eller i fremtiden.");
                    }
                }
                return ValidationResult.Success;
            }
        }
    }
}
