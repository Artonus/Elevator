using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.DataAccess.Model;

namespace ElevatorCore.DataAccess
{
    /// <summary>
    /// Database context that connects Entity Framework to our database
    /// </summary>
    public class ElevatorContext : DbContext
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ElevatorContext() : base("Elevator") // specifying name of the connection string in App.config
        {
            
        }

        /// <summary>
        /// Database set of Log table
        /// </summary>
        public DbSet<Log> Logs { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer<ElevatorContext>(null);
        }
    }
}
