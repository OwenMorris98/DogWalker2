using Microsoft.AspNetCore.Mvc;
using DogWalker2.Api.Customers;
using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Application.Customers;
using System.Drawing.Printing;
using MediatR;
using DogWalker2.Application.Customers.Commands.CreateCommands;
using Microsoft.EntityFrameworkCore.Infrastructure;
using DogWalker2.Application.Dogs.Commands.CreateCommands;
using DogWalker2.Application.Dogs.DTOs;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
        public IEnumerable<string> Get(string CustomerId)
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public string Get(string customerId, string id)
        {
            return "value";
        }

        // POST api/<DogController>
        [HttpPost]
        public async Task<IActionResult> Post(string CustomerId, [FromBody] DogDTO dog)
        {
            dog.customer_id = CustomerId;
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
