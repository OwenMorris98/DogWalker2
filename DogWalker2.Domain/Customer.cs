using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DogWalker2.Domain.Walks;
using DogWalker2.Domain.Users;

namespace DogWalker2.Domain
{
    public class Customer
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string email { get; set; }

        public string passwordHash { get; set; }

        public string? first_name { get; set; }

        public string? last_name { get; set; }


       // public IEnumerable<Dog> _dogs { get => Dogs.AsEnumerable(); set => Dogs = value.ToList(); }

        public List<Dog> Dogs { get; set; } 

        //public IEnumerable<Payment> _payments => Payments;

        public List<Payment> Payments { get; set; }


        public Customer(string id, string email, string passwordHash)
        {
            Id = id;
            this.email = email;
            this.passwordHash = passwordHash;
        
          
        }

        public Customer Create(string email, string passwordHash)
        {
            return new Customer(Guid.NewGuid().ToString(), email, passwordHash);
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
