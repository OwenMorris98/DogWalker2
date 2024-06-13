using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Domain.Walks
{
    public class Walker
    {
        public int WalkerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ExperienceLevel { get; set; }
        public string Availability { get; set; }
        public List<Walk> Walks { get; set; }
        public List<Payment> Payments { get; set; }

        public Walker() { }
        public Walker(int walkerID, string name, string email, string phone, string experienceLevel, string availability)
        {
            WalkerID = walkerID;
            Name = name;
            Email = email;
            Phone = phone;
            ExperienceLevel = experienceLevel;
            Availability = availability;
            Walks = new List<Walk>();
            Payments = new List<Payment>();
        }

        public void AddWalk(Walk walk)
        {
            Walks.Add(walk);
        }

        public void AddPayment(Payment payment)
        {
            Payments.Add(payment);
        }

    }
}
