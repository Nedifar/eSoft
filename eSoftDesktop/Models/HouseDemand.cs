using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class HouseDemand : Demand
    {
        public int minArea { get; set; }
        public int maxArea { get; set; }
        public int minRooms { get; set; }
        public int maxRooms { get; set; }
        public int minFloors { get; set; }
        public int maxFloors { get; set; }
    }
}
