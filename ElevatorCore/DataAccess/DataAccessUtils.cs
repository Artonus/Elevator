using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.DataAccess
{
    public static class DataAccessUtils
    {
        public static string GetConnectionString(string name = "Elevator")
        {
            var retVal = ConfigurationManager.ConnectionStrings[0];
            return retVal.ConnectionString;
        }
    }
}
