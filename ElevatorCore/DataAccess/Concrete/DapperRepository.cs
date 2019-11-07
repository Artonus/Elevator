using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using ElevatorCore.DataAccess.Abstract;

namespace ElevatorCore.DataAccess.Concrete
{
    class DapperRepository<TRecord> : IRepository<TRecord> where TRecord : class
    {
        private IDbConnection _conn;
        private IDbTransaction _transaction;
        public DapperRepository(IDbTransaction transaction)
        {
            _transaction = transaction;
            _conn = transaction.Connection;
            
        }
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _transaction.Dispose();
                    _transaction.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Delete(TRecord entity)
        {
            _conn.Delete<TRecord>(entity);
        }

        public void Delete(object id)
        {
            var record = GetByID(id);
            Delete(record);
        }

        public TRecord GetByID(object id)
        {
            return _conn.Get<TRecord>(id);
        }

        public IEnumerable<TRecord> GetAllLogs()
        {
            return _conn.GetAll<TRecord>();
        }

        public void Insert(TRecord record)
        {
            _conn.Insert(record);
        }

        public void Update(TRecord record)
        {
            _conn.Update(record);
        }
    }
}
