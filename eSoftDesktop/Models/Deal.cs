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
        public int IdDeal { get; set; }
        public int IdDemand { get; set; }
        public int IdSupply { get; set; }
        public Demand Demand { get; set; }
        public Supply Supply { get; set; }
    }
}
