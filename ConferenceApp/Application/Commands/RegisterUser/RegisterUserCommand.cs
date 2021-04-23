using MediatR;
using Microsoft.AspNetCore.Http;

namespace ConferenceApp.Application.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<int>
    {
        public int ConferenceVariantId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public IFormFile? Photo { get; set; }
    }
}