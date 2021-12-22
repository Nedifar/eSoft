using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class Realtor
    {
        [Key]
        public int realtorId { get; set; }
        public string lastName { get; set; }
        public string Name { get; set; }
        public string middleName { get; set; }
        [Range(0, 100)]
        public int comissionPart { get; set; }
        public List<Demand> Demands { get; set; } = new List<Demand>();
        public List<Supply> Supplies { get; set; } = new List<Supply>();
    }
}
