using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class OutputHouse
    {
        public int Id { get; set; }
        public string adressCity { get; set; }
        public string adressStreet { get; set; }
        public string addressHouse { get; set; }
        public string addressNumber { get; set; }
        public string coordinateLatitude { get; set; }
        public string coordinateLongitude { get; set; }
        public double totalArea { get; set; }
        public int Rooms { get; set; }
        public int Floor { get; set; }
        public string Type { get; set; }
    }
}
