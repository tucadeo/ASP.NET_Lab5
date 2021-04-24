using System.ComponentModel.DataAnnotations;

namespace ConferenceApp.Models
{
    public class ConferenceUserViewModel
    {
        public int Id { get; init; }

        [Display(Name = "Imię")]
        public string FirstName { get; init; } = default!;
        [Display(Name = "Nazwisko")]
        public string LastName { get; init; } = default!;
        public string Email { get; init; } = default!;

        [Display(Name = "Zdjęcie")]
        public string? PhotoUrl { get; init; }

        [Display(Name = "Typ konferencji")]
        public string ConferenceType { get; init; } = default!;
    }
}
