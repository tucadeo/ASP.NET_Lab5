using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConferenceApp.Models
{
    public class RegisterConferenceUserViewModel
    {
        public RegisterConferenceUserViewModel()
        {
            ConferenceVariants = new List<SelectListItem>();
            ConferenceUsers = new List<ConferenceUserViewModel>();
        }

        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; } = default!;

        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; } = default!;
        
        [Required]
        public string Email { get; set; } = default!;
        
        [Display(Name = "Zdjęcie")]
        public IFormFile? Photo { get; set; }

        [Required]
        [Display(Name = "Typ konferencji")]
        public string ConferenceType { get; set; } = default!;

        public List<SelectListItem> ConferenceVariants { get; set; }
        public List<ConferenceUserViewModel> ConferenceUsers { get; set; }
    }
}