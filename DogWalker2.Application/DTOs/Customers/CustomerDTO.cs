
using DogWalker2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DogWalker2.Application.DTOs.Customers
{
    public class CustomerDTO
    {
        public string email {  get; set; }

        public string password { get; set; }

        public string? first_name { get; set; }

        public string? last_name { get; set; }

    }

   
}
