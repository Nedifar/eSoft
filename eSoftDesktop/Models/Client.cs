using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class Client
    {
        [Key]
        public int clientId { get; set; }
        public string lastName { get; set; }
        public string Name { get; set; }
        public string middleName { get; set; }
        public string Telephone { get; set; }
        public string eMail { get; set; }
        public List<Demand> Demands { get; set; }
        public List<Supply> Supplies { get; set; }  =new List<Supply>();
    }
}
