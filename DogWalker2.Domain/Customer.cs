using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DogWalker2.Domain.Walks;

namespace DogWalker2.Domain
{
    public class Customer
    {
        public string Id { get; set; }

        public string? first_name { get; set; }

        public string? last_name { get; set; }

        public string? address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zipcode { get; set; }

       // public IEnumerable<Dog> _dogs { get => Dogs.AsEnumerable(); set => Dogs = value.ToList(); }

        public List<Dog> Dogs { get; set; } 

        //public IEnumerable<Payment> _payments => Payments;

        public List<Payment> Payments { get; set; }

        public Customer(string id, string? first_name, string? last_name, string? address, string? city, string? state, string? zipcode)
        {
            Id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
          
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
