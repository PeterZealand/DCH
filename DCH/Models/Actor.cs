using System.ComponentModel.DataAnnotations;

namespace DCH.Models
{
    public class Actor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Indtsast venligst fornavn"),
            MinLength(1), MaxLength(15),]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Indtsast venligst efternavn"),
            MinLength(1), MaxLength(15),]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Indtsast venligst email-adresse"),
            MinLength(1), MaxLength(40),]
        public string Email { get; set; }

        [Required(ErrorMessage = "Indtsast venligst adresse"),
            MinLength(1), MaxLength(100),]
        public string Address { get; set; }

        [Required(ErrorMessage = "Indtsast venligst by"),
            MinLength(1), MaxLength(20),]
        public string City { get; set; }

        public int PhoneNumber { get; set; }

        public bool Dog { get; set; }
        
    }
}
