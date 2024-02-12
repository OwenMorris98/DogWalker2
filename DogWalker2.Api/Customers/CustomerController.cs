using DogWalker2.Api.Customers.DTOs;
using DogWalker2.Application.Customers.Commands.CreateCommands;
using DogWalker2.Application.Customers.Commands.DeleteCommands;
using DogWalker2.Application.Customers.Commands.UpdateCommands;
using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Domain.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DogWalker2.Api.Customers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Route("/AddCustomer")]
        public async Task Post([FromBody] AddCustomerDTO customer)
        {
            var request = new CreateCustomerCommand(customer);
            try
            {
                await _mediator.Send(request);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] UpdateCustomerDTO customer)
        {
            var request = new UpdateCustomerCommand(id, customer);
            try
            {
                await _mediator.Send(request);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var request = new DeleteCustomerCommand(id);
            try
            {
                await _mediator.Send(request);
            }
            catch
            {
                throw new NotImplementedException();    
            }
        }
    }
}
