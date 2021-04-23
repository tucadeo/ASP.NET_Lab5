using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConferenceApp.Application.Queries.GetConferenceVariants
{
    public class GetConferenceVariantsQuery : IRequest<List<SelectListItem>>
    {
    }
}