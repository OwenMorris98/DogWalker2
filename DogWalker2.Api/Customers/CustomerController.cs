using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Application.Customers.Commands.CreateCommands;
using DogWalker2.Application.Customers.Commands.DeleteCommands;
using DogWalker2.Application.Customers.Commands.UpdateCommands;
using DogWalker2.Application.Customers.Queries.GetAllCustomers;
using DogWalker2.Domain.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using DogWalker2.Application.Customers.Queries.GetById;

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
        public async Task<IActionResult> Get()
        {
            var query = new GetCustomerQuery();
            try
            {
                var customers = await _mediator.Send(query);
                return Ok(customers);
            }
            catch
            {
                return NotFound();
            }
            
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var query = new GetCustomerByIdQuery(id);

            try
            {
                var customer = await _mediator.Send(query);
                return Ok(customer);
            }
            catch
            {
                return NotFound();
            }
        
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDTO customer)
        {
            // var request = new CreateCustomerCommand(customer);
            try
            {
                var command = new CreateCustomerCommand(customer);
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] CustomerDTO customer)
        {
            var request = new UpdateCustomerCommand(id, customer);
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
