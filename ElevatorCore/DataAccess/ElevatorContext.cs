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
    class ElevatorContext : DbContext
    {
        public ElevatorContext()
        {
            Database.SetInitializer<ElevatorContext>(null);
        }

        public DbSet<Log> Logs { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
