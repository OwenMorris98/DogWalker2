﻿using DogWalker2.Domain;
using DogWalker2.Domain.Walks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Dogs.DTOs
{
    public class WalkDTO
    {
       
        public Dog Dog { get; set; }
        public Walker Walker { get; set; }
        public DateTime ScheduledTime { get; set; }
        public int Duration { get; set; }
        public Location? Location { get; set; }

        public string Status { get; set; }
        public string Notes { get; set; }

        
    }
}
