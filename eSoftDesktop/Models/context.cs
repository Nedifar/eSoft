using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSoftDesktop.Models
{
    public class context : DbContext
    {
        private static context _context;
        public context() : base("sql") { }
        public static context aGetContext()
        {
            if (_context == null)
                _context = new context();
            return _context;
        }
        public DbSet<Models.MainAHL> MainAHLs { get; set; }
        public DbSet<Models.Land> Lands { get; set; }
        public DbSet<Models.Apartament> Apartaments { get; set; }
        public DbSet<Models.House> Houses { get; set; }
        public DbSet<Models.Demand> Demands { get; set; }
        public DbSet<Models.HouseDemand> HouseDemands { get; set; }
        public DbSet<Models.LandDemand> LandDemands { get; set; }
        public DbSet<Models.ApartamentDemand> ApartamentDemands{ get; set; }
        public DbSet<Models.Client> Clients { get; set; }
        public DbSet<Models.Realtor> Realtors { get; set; }
        public DbSet<Models.Supply> Supplies { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Deal> Deals { get; set; }
    }
}
