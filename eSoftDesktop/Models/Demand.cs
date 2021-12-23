using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class Demand
    {
        [Key]
        public int idDemand { get; set; }
        public int idClient { get; set; }
        public Client Client { get; set; }
        public int idRealtor { get; set; }
        public Realtor Realtor { get; set; }
        public string typeEstate { get; set; }
        public string addressCity { get; set; }
        public string addressStreet { get; set; }
        public string addressHouse { get; set; }
        public string addressNumber { get; set; }
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
        public List<HouseDemand> HouseDemands { get; set; } = new List<HouseDemand>();
        public List<LandDemand> LandDemands{ get; set; } = new List<LandDemand>();
        public List<ApartamentDemand> ApartamentDemands{ get; set; } = new List<ApartamentDemand>();
    }
}
