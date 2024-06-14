using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogWalker2.Domain.Walks;
using Microsoft.EntityFrameworkCore;
using DogWalker2.Application.Commands.Walks;
using DogWalker2.Application.DTOs.Walks;

namespace DogWalker2.Api.Walks
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ScheduleWalk(ScheduleWalkRequest request)
        {
            var command = new ScheduleWalkCommand(request);
            var walkToSchedule = await _mediator.Send(command);
            return Ok();
        }
    }
}
