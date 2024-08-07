using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogWalker2.Domain.Walks;
using Microsoft.EntityFrameworkCore;
using DogWalker2.Application.Commands.Walks;
using DogWalker2.Application.Queries.Walks;
using DogWalker2.Application.Queries.Walks.GetWalks;
using DogWalker2.Application.Queries.Walks.GetWalksById;
using DogWalker2.Application.DTOs.Walks;

namespace DogWalker2.Api.Walks
{
    [Route("api/{customerId}/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Walks([FromRoute] string customerId)
        {
            var walks = await _mediator.Send(new GetWalksQuery(customerId));
            return Ok(walks);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Walks(int id)
        {
            var walk = await _mediator.Send(new GetWalksByIdQuery(id));
            return Ok(walk);
        }


        [HttpPost]
        public async Task<IActionResult> Walks(ScheduleWalkRequest request)
        {
            var command = new ScheduleWalkCommand(request);
            var walkToSchedule = await _mediator.Send(command);
            return CreatedAtAction(nameof(Walks),new {walkToSchedule.id});
        }
    }
}
