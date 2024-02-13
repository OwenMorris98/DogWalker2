﻿namespace DogWalker2.Application.Customers.DTOs
{
    public class AddCustomerDTO
    {

        public string Id { get; set; }
        public string first_name { get; set; }

        public string last_name { get; set;}

        public string? address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zipcode { get; set; }

    }
}
