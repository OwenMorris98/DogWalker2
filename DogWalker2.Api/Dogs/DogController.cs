﻿using Microsoft.AspNetCore.Mvc;
using DogWalker2.Api.Customers;
using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Application.Customers;
using System.Drawing.Printing;
using MediatR;
using DogWalker2.Application.Customers.Commands.CreateCommands;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DogWalker2.Api.Dogs
{
    [Route("api/[controller]")]
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<DogController>
        //[HttpPost]
        //public async void Post([FromBody] AddCustomerDTO customer)
        //{
        //    var request = new CreateCustomerCommand(customer);
        //    try
        //    {
        //        await _mediator.Send(request);
        //    }
        //    catch
        //    {
        //        throw new NotImplementedException();
        //    }


        //}

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
