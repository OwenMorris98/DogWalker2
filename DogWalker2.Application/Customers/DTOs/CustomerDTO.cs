﻿using DogWalker2.Domain.Dogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Customers.DTOs
{
    public class CustomerDTO
    {
        public string Id { get; set; }

        public string? first_name { get; set; }

        public string? last_name { get; set; }

        public string? address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zipcode { get; set; }

        public CustomerDTO()
        {
            
        }

        public CustomerDTO(string id, string? first_name, string? last_name, string? address, string? city, string? state, string? zipcode)
        {
            Id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
        }
    }
}
