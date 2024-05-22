using DogWalker2.Application.Dogs.DTOs;
using DogWalker2.Domain.Dogs;
using DogWalker2.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DogWalker2.Application.Customers.DTOs
{
    public class CustomerDTO
    {
   
        public string? first_name { get; set; }

        public string? last_name { get; set; }

        public string? address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zipcode { get; set; }


       


    }
}
