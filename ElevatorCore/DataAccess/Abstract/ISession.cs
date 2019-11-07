using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.DataAccess.Model;

namespace ElevatorCore.DataAccess.Abstract
{
    public interface ISession
    {
        IRepository<Log> Logs { get; }
        void Commit();
    }
}
