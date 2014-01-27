using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.strava.api.Gear
{
    public class Bike : IGear
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Id { get; set; }
        public bool IsPrimary { get; set; }
        public string Name { get; set; }
        public float Distance { get; set; }
        public String Description { get; set; }

        public BikeType BikeType { get; set; }
    }
}
