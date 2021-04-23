using System.Runtime.Serialization;

namespace ConferenceApp.Persistence.Enums
{
    public enum ConferenceType
    {
        [EnumMember(Value = "Workshop")]
        Workshop,
        [EnumMember(Value = "Lecture")]
        Lecture,
        [EnumMember(Value = "Remote")]
        Remote
    }
}