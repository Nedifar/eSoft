using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class Supply
    {
        [Key]
        public int idSupply { get; set; }
        public int idClient { get; set; }
        public Client Client { get; set; }
        public int idRealtor { get; set; }
        public Realtor Realtor { get; set; }
        public int idAHL { get; set; }
        public MainAHL MainAHL { get; set; }
        public int Price { get; set; }
    }
}
