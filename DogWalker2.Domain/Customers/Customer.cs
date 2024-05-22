using DogWalker2.Domain.Dogs;
using DogWalker2.Domain.Payments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public List<Payment> Payments { get; set; }

        public Customer(string id, string? first_name, string? last_name, string? address, string? city, string? state, string? zipcode, ICollection<Dog> dogs, List<Payment> payments)
        {
            Id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
            Dogs = dogs;
            Payments = payments;
        }

        public Customer()
        {
        }

        public void AddDog(Dog dog)
        {
            Dogs.Add(dog);
        }

        public void AddPayment(Payment payment)
        {
            Payments.Add(payment);
        }


    }
}
