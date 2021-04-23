namespace ConferenceApp.Persistence.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int ConferenceVariantId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? PhotoUrl { get; set; } 

        public virtual ConferenceVariant ConferenceVariant { get; set; } = default!;
    }
}