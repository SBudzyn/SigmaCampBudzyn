using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    internal class EnergyContext : DbContext
    {
        public DbSet<ApartmentData> Apartments { get; set; } = null!;
        public EnergyContext() : base()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=energydb;Trusted_Connection=True;");
        }

    }
}
