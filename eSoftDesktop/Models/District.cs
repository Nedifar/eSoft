using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class District
    {
        [Key]
        public int districtId { get; set; }
        public string Name { get; set; }
        public string area { get; set; }
    }
}
