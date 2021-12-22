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
        public int supplyId { get; set; }
        public int clientId { get; set; }
        public Client Client { get; set; }
        public int realtorId { get; set; }
        public Realtor Realtor { get; set; }
        public int Id { get; set; }
        public MainHome MainHome { get; set; }
        public int Price { get; set; }
    }
}
