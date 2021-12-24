using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class Land
    {
        [Key]
        public int idLand { get; set; }
        public int idAHL { get; set; }
        public MainAHL MainAHL { get; set; }
    }
}
