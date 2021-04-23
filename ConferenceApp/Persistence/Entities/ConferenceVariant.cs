using ConferenceApp.Persistence.Enums;

namespace ConferenceApp.Persistence.Entities
{
    public class ConferenceVariant
    {
        public int Id { get; set; }
        public ConferenceType ConferenceType { get; set; }
    }
}