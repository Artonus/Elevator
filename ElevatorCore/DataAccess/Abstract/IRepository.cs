using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.DataAccess.Model;

namespace ElevatorCore.DataAccess.Abstract
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {

        void Delete(TEntity entity);

        void Delete(object id);

        TEntity GetByID(object id);
        IEnumerable<TEntity> GetAllLogs();
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}
