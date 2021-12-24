using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class Deal
    {
        [Key]
        public int idDeal { get; set; }
        public int idDemand { get; set; }
        public Demand Demand { get; set; }
        public int idSupply { get; set; }
        public Supply Supply { get; set; }
    }
}
