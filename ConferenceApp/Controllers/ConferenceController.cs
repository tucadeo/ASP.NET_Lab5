using ConferenceApp.Models;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ConferenceApp.Application.Queries.GetConferenceUsers;
using ConferenceApp.Application.Queries.GetConferenceVariants;
using ConferenceApp.Mappings;
using MediatR;

namespace ConferenceApp.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IMediator _mediator;

        public ConferenceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Register()
        {
            var conferenceTypes = await _mediator.Send(new GetConferenceVariantsQuery());
            var conferenceUsers = await _mediator.Send(new GetConferenceUsersQuery());

            var registerUserVm = new RegisterConferenceUserViewModel
            {
                ConferenceUsers = conferenceUsers,
                ConferenceVariants = conferenceTypes
            };

            return View(registerUserVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateDNTCaptcha(
            ErrorMessage = "Prosze podać prawidłowy numer",
            CaptchaGeneratorLanguage = Language.English,
            CaptchaGeneratorDisplayMode = DisplayMode.ShowDigits)]
        public async Task<ActionResult> Register(RegisterConferenceUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _mediator.Send(model.ToCommand());

                TempData["AddedItemId"] = userId;

                return RedirectToAction(nameof(Register));
            }

            return View(model);
        }
    }
}