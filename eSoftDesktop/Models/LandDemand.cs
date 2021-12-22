using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class LandDemand : Demand
    {
        public int minArea { get; set; }
        public int maxArea { get; set; }
    }
}
