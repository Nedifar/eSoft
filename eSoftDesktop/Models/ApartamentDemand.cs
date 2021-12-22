using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class ApartamentDemand : Demand
    {
        public int minArea { get; set; }
        public int maxArea { get; set; }
        public int minRooms { get; set; }
        public int maxRooms { get; set; }
    }
}
