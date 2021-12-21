using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class contetx : DbContext
    {
        private static contetx _context;
        public contetx() : base("sql") { }
        public static contetx aGetContext()
        {
            if (_context == null)
                _context = new contetx();
            return _context;
        }
        public DbSet<Realtor> Realtors { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Apartament> Apartaments { get; set; }
        public DbSet<Land> Lands { get; set; }
    }
}
