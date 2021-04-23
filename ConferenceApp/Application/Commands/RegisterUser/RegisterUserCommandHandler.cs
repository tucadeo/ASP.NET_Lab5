using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ConferenceApp.Mappings;
using ConferenceApp.Persistence;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace ConferenceApp.Application.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly AppDbContext _context;
        private readonly IHostEnvironment _env;

        public RegisterUserCommandHandler(AppDbContext context, IHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            string? uniqueFileName = null;

            var hasPhoto = request.Photo is not null;

            if (hasPhoto)
            {
                string uploadsFolder = Path.Combine(_env.ContentRootPath, "wwwroot/images");
                uniqueFileName = $"{Guid.NewGuid()}_{request.Photo!.FileName}";
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                await using var fileStream = new FileStream(filePath, FileMode.Create);
                await request.Photo.CopyToAsync(fileStream, cancellationToken);
            }

            var photoUrl = hasPhoto ? $"~/images/{uniqueFileName}" : null;

            var user = request.ToEntity(photoUrl);
  
            _context.Users.Add(user);

            var success = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (success) return user.Id;

            throw new Exception("Problem registering user");
        }
    }
}