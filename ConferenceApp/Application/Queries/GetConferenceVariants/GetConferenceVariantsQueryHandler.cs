using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConferenceApp.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Application.Queries.GetConferenceVariants
{
    public class GetConferenceVariantsQueryHandler : IRequestHandler<GetConferenceVariantsQuery, List<SelectListItem>>
    {
        private readonly AppDbContext _context;

        public GetConferenceVariantsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SelectListItem>> Handle(GetConferenceVariantsQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.ConferenceVariants
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.ConferenceType.ToString()
                })
                .ToListAsync(cancellationToken);
        }
    }
}