using Microsoft.AspNetCore.Mvc;
using DogWalker2.Api.Customers;
using DogWalker2.Application.DTOs.Customers;
using DogWalker2.Application;
using System.Drawing.Printing;
using MediatR;
using DogWalker2.Application.Commands.Customers.CreateCommands;
using Microsoft.EntityFrameworkCore.Infrastructure;
using DogWalker2.Application.Commands.Dogs.CreateCommands;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using DogWalker2.Application.DTOs.Dogs;
using DogWalker2.Application.Queries.Customers.GetAllCustomers;
using DogWalker2.Application.Queries.Dogs.GetDogsByCustomerId;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DogWalker2.Api.Dogs
{
    [Route("api/{CustomerId}/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DogController(IMediator mediator)
        {
            _mediator = mediator;
        }



        // GET: api/<DogController>
        [HttpGet]
        public async Task<IActionResult> GetDogsByCustomerId(string CustomerId)
        {
            var query = new GetDogsByCustomerIdQuery(CustomerId);
            try
            {
                var dogs = await _mediator.Send(query);
                if (dogs != null)
                {
                    return Ok(dogs);
                }
                else
                {

                   return NotFound();
                }
            }    
                
            catch
            {
                return NotFound ();
            }
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public string Get(string customerId, string id)
        {
            return "value";
        }

        // POST api/<DogController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(string CustomerId, [FromBody] PostDogRequest dog)
        {
            
            var request = new CreateDogCommand(dog);
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch
            {
                throw new NotImplementedException();
            }


        }

        //[HttpPost]
        //public async Task<IActionResult> PostWalk(string customerId )

        // PUT api/<DogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
