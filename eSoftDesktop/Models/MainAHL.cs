using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class MainAHL
    {
        [Key]
        public int idAHL { get; set; }
        public string adressCity { get; set; }
        public string adressStreet { get; set; }
        public string addressHouse { get; set; }
        public string addressNumber { get; set; }
        public string coordinateLatitude { get; set; }
        public string coordinateLongitude { get; set; }
        public double totalArea { get; set; }
        public List<House> Houses { get; set; } = new List<House>();
        public List<Apartament> Apartaments { get; set; } = new List<Apartament>();
        public List<Land> Lands { get; set; } = new List<Land>();
        public List<Supply> Supplies { get; set; } = new List<Supply>();
    }
}
