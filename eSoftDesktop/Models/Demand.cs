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
        public int demandId { get; set; }
        public int clientId { get; set; }
        public Client Client { get; set; }
        public int realtorId { get; set; }
        public Realtor Realtor { get; set; }
        public string typeEstate { get; set; }
        public string address { get; set; }
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
    }
}
