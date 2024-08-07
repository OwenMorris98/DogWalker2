using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using DogWalker2.Application.Commands.Users;
using Microsoft.AspNetCore.Authorization;
using DogWalker2.Application.Commands.Customers.CreateCommands;
namespace DogWalker2.Api.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

       [HttpPost("Login")]
       public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var command = new LoginCommand(request.Email, request.Password);
            var response = await _mediator.Send(command, cancellationToken);

            if (response.token.Contains("Invalid"))
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateCustomerCommand(request.email, request.password);
            var response = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(Register), response.email);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            return Ok("User is logged in");
        }
    }
}
