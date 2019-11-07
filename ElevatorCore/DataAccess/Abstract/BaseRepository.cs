using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.DataAccess.Abstract
{
    class BaseRepository<TRecord> : IRepository<TRecord> where TRecord : class
    {
        internal ElevatorContext Context;

        internal DbSet<TRecord> DbSet;

        public BaseRepository(ElevatorContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TRecord>();
        }

        public void Delete(TRecord record)
        {
            DbSet.Remove(record);
        }

        public void Delete(object id)
        {
            var record = DbSet.Find(id);
            Delete(record);
        }

        public TRecord GetByID(object id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TRecord> GetAllLogs()
        {
            return DbSet.ToList();
        }

        public void Insert(TRecord record)
        {
            DbSet.Add(record);
        }

        public void Update(TRecord recordToUpdate)
        {
            DbSet.Attach(recordToUpdate);
            //Context.Entry(recordToUpdate).State = EntityState.Modified;
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
