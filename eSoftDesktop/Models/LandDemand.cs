using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class LandDemand
    {
        [Key]
        public int idLandDemand { get; set; }
        public int idDemand { get; set; }
        public Demand Demand { get; set; }
        public int? minArea { get; set; }
        public int? maxArea { get; set; }
    }
}
