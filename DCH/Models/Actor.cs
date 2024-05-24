﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static DCH.Pages.Actors.CreateActorsModel;

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

        public string Password { get; set; }

        [Required(ErrorMessage = "Indtsast venligst adresse"),
            MinLength(1), MaxLength(100),]
        public string Address { get; set; }

        [Required(ErrorMessage = "Indtsast venligst by"),
            MinLength(1), MaxLength(20),]
        public string City { get; set; }

        [Required(ErrorMessage = "Indtast venligst telefonnummer")]
        //[StringLength(8, ErrorMessage = "Telefonnummer må højst være 8 tegn")]
        [MinLength(8), MaxLength(8), NumericOnly]
        public string PhoneNumber { get; set; }

        public bool Dog { get; set; }

        
        //denne kode skal vi lige helt forstå og ha styr på om virker - ser ud til at virke men kan den forklares ?
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
