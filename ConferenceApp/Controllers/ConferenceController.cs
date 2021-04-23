using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var (users, variants) = await GetUsersAndVariantsAsync();

            var registerUserVm = new RegisterConferenceUserViewModel
            {
                ConferenceUsers = users,
                ConferenceVariants = variants
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

            var (users, variants) = await GetUsersAndVariantsAsync();

            model.ConferenceUsers = users;
            model.ConferenceVariants = variants;

            return View(model);
        }

        private async Task<(List<ConferenceUserViewModel> users, List<SelectListItem> variants)>
            GetUsersAndVariantsAsync()
        {
            var users = await _mediator.Send(new GetConferenceUsersQuery());
            var variants = await _mediator.Send(new GetConferenceVariantsQuery());

            return (users, variants);
        }
    }
}