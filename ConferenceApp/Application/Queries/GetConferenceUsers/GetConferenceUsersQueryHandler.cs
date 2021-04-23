using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConferenceApp.Models;
using ConferenceApp.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Application.Queries.GetConferenceUsers
{
    public class
        GetConferenceUsersQueryHandler : IRequestHandler<GetConferenceUsersQuery, List<ConferenceUserViewModel>>
    {
        private readonly AppDbContext _context;

        public GetConferenceUsersQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConferenceUserViewModel>> Handle(GetConferenceUsersQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Users
                .Include(x => x.ConferenceVariant)
                .Select(x => new ConferenceUserViewModel
                {
                    Id = x.Id,
                    ConferenceType = x.ConferenceVariant.ConferenceType.ToString(),
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhotoUrl = x.PhotoUrl,
                })
                .ToListAsync(cancellationToken);
        }
    }
}