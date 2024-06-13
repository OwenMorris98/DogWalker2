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
        public Location? Location { get; set; }

        public string Status { get; set; }
        public string Notes { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public Walk(int walkID, Dog dog, Walker walker, DateTime scheduledTime, int duration, Location? location, string status, string notes)
        {
            WalkID = walkID;
            Dog = dog;
            Walker = walker;
            ScheduledTime = scheduledTime;
            Duration = duration;
            Location = location;
            Status = status;
            Notes = notes;
        }

        public Walk() { }
    }

}
