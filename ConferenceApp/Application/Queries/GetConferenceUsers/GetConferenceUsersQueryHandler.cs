using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ConferenceApp.Models;
using ConferenceApp.Persistence;
using ConferenceApp.Persistence.Entities;
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
                .Select(Projection)
                .ToListAsync(cancellationToken);
        }

        private static readonly Expression<Func<User, ConferenceUserViewModel>> Projection =
            user => new ConferenceUserViewModel
            {
                Id = user.Id,
                ConferenceType = user.ConferenceVariant.ConferenceType.ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhotoUrl = user.PhotoUrl,
            };
    }
}