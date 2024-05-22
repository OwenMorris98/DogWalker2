using DogWalker2.Domain.Walks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Domain.Locations
{
    public class Location
    {
        public int LocationID { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<Walk> Walks { get; set; }

        public Location() { }

        public Location(int locationID, string address, double latitude, double longitude)
        {
            LocationID = locationID;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }
    }

}
