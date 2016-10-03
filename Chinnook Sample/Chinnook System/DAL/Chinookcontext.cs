using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using System.Data.Entity;
using Chinnook_System.Data.Entities;
#endregion
namespace Chinnook_System.DAL
{
    // internal for security reasons
    // Access restricted within the component library
    // Inherit db Context for Entity Framework requires System.Data.Entity
    internal class Chinookcontext : DbContext
    {
        // Pass the connection string name to the 
        // DBContext using the :base("connection name")
        public Chinookcontext() : base("ChinookDB")
        {

        }
        // setup DBSet properties
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Tracks> Tracks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
