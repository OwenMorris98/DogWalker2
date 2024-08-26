using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using DogWalker2.Domain.Services;

namespace DogWalker2.Domain.Walks
{


    public class Walk
    {
        public int WalkID { get; set; }
        public Dog Dog { get; set; }
        public Walker Walker { get; set; }
        public DateTime ScheduledTime { get; set; }
        public int Duration { get; set; }
        public string Address { get; set; }

        //public decimal price { get; set; }

        public string Status { get; init; } = "Pending";
        public string Notes { get; set; }

        public List<Payment> WalkPayments { get; set; }

        //public IEnumerable<Payment> _walkPayments => WalkPayments;
        public Walk(int walkID, Dog dog, Walker walker, DateTime scheduledTime, int duration, string address, string status, string notes)
        {
            WalkID = walkID;
            Dog = dog;
            Walker = walker;
            ScheduledTime = scheduledTime;
            Duration = duration;
            Address = address;
            Status = status;
            Notes = notes;
        }

        public Walk() { }


        public string flipStatus(string status)
        {
            if (String.IsNullOrEmpty(status))
            {
                throw new Exception("status is null");
            }

            if(status.Equals("Pending"))
            {
                return "Completed";
            }
            else if (status.Equals("Completed"))
            {
                return "Pending";
            }
            else
            {
                throw new Exception("status is not Pending or Completed");
            }
        }

        public int IncreaseDuration(int increase)
        {
            if (increase <= 0)
            {
                throw new Exception("duration is negative");
            }
            return this.Duration + increase;
        }

        public async Task SendScheduledEmail(IEmailSender<Customer> sender, Customer customer, Walk walk)
        {
           await sender.SendWalkScheduledAsync(customer, walk);
        }
    }

}
