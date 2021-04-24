using MediatR;
using Microsoft.AspNetCore.Http;

namespace ConferenceApp.Application.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<int>
    {
        public int ConferenceVariantId { get; init; }
        public string FirstName { get; init; } = default!;
        public string LastName { get; init; } = default!;
        public string Email { get; init; } = default!;
        public IFormFile? Photo { get; init; }
    }
}