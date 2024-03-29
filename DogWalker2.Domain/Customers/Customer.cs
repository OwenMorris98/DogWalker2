using DogWalker2.Domain.Dogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Domain.Customers
{
    public class Customer
    {
        public string Id { get; set; }
        
        public string? first_name { get; set; }

        public string? last_name { get; set;}

        public string? address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zipcode { get; set; }

        public ICollection<Dog> Dogs { get; set; } = new List<Dog>();

     


    }
}
