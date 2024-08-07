using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

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

        public string Status { get; set; }
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

      
    }

}
