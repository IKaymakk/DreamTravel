using DreamTravel.CQRS.Commands.GuideCommands;
using DreamTravel.CQRS.Queries.GuideQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetGuide(int id)
        {
            var values = await _mediator.Send(new GetGuideByIdQuery(id));
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
