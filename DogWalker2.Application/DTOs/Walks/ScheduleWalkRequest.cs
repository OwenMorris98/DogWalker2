using DogWalker2.Domain.Walks;
using DogWalker2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.DTOs.Walks
{
    public class ScheduleWalkRequest
    {

        public string DogID { get; set; }
        public int? WalkerID { get; set; }
        public DateTime ScheduledTime { get; set; }
        public int Duration { get; set; }
        public int LocationID { get; set; }

        public string Status { get; set; }
        public string Notes { get; set; }
    }
}
