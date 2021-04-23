using System.ComponentModel.DataAnnotations;

namespace ConferenceApp.Models
{
    public class ConferenceUserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Imię")]
        public string FirstName { get; set; } = default!;
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;

        [Display(Name = "Zdjęcie")]
        public string? PhotoUrl { get; set; }

        [Display(Name = "Typ konferencji")]
        public string ConferenceType { get; set; } = default!;
    }
}
