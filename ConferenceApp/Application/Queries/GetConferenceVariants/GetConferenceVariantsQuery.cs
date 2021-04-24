using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConferenceApp.Application.Queries.GetConferenceVariants
{
    public record GetConferenceVariantsQuery : IRequest<List<SelectListItem>>;
}