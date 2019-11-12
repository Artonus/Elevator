using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.DataAccess.Model;

namespace ElevatorCore.DataAccess.Abstract
{
    /// <summary>
    /// Manages connection between UI and Database to implement Unit Of Work pattern
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// Repository of Logs
        /// </summary>
        IRepository<Log> Logs { get; }
        /// <summary>
        /// Saves all changes made to Database
        /// </summary>
        void Commit();
    }
}
