using ConferenceApp.Application.Commands.RegisterUser;
using ConferenceApp.Models;
using ConferenceApp.Persistence.Entities;

namespace ConferenceApp.Mappings
{
    public static class UserMappings
    {
        public static RegisterUserCommand ToCommand(this RegisterConferenceUserViewModel model)
        {
            return new()
            {
                ConferenceVariantId = int.Parse(model.ConferenceType),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Photo = model.Photo
            };
        }

        public static User ToEntity(this RegisterUserCommand command, string? photoUrl)
        {
            return new()
            {
                ConferenceVariantId = command.ConferenceVariantId,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                PhotoUrl = photoUrl
            };
        }
    }
}