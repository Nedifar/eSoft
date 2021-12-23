using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class ApartamentDemand
    {
        [Key]
        public int idApartamentDemand { get; set; }
        public int idDemand { get; set; }
        public Demand Demand { get; set; }
        public int? minArea { get; set; }
        public int? maxArea { get; set; }
        public int? minRooms { get; set; }
        public int? maxRooms { get; set; }
        public int? minFloors { get; set; }
        public int? maxFloors { get; set; }
    }
}
