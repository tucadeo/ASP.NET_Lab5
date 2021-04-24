using System.Collections.Generic;
using ConferenceApp.Models;
using MediatR;

namespace ConferenceApp.Application.Queries.GetConferenceUsers
{
    public record GetConferenceUsersQuery : IRequest<List<ConferenceUserViewModel>>;
}