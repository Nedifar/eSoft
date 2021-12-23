using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class House
    {
        [Key]
        public int idHouse { get; set; }
        public int idAHL { get; set; }
        public MainAHL MainAHL { get; set; }
        public int Floor { get; set; }
    }
}
