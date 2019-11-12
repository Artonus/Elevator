using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.DataAccess.Abstract;

namespace ElevatorCore.DataAccess.Concrete
{
    /// <summary>
    /// Basic repository
    /// </summary>
    /// <typeparam name="TRecord"></typeparam>
    public class BaseRepository<TRecord> : IRepository<TRecord> where TRecord : class
    {
        /// <summary>
        /// EF6 database context
        /// </summary>
        internal ElevatorContext Context;

        /// <summary>
        /// EF6 set of DB records
        /// </summary>
        internal DbSet<TRecord> DbSet;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(ElevatorContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TRecord>();
        }

        /// <summary>
        /// Deletes record from data set
        /// </summary>
        /// <param name="record"></param>
        public virtual void Delete(TRecord record)
        {
            DbSet.Remove(record);
        }

        /// <summary>
        /// Deletes record from data set by its ID
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            var record = DbSet.Find(id);
            Delete(record);
        }

        /// <summary>
        /// Finds record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TRecord GetByID(object id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Gets all records from data set
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TRecord> GetAll()
        {
            return DbSet.ToList();
        }

        /// <summary>
        /// Inserts new record to data set
        /// </summary>
        /// <param name="record"></param>
        public virtual void Insert(TRecord record)
        {
            DbSet.Add(record);
        }

        /// <summary>
        /// Updates record in data set
        /// </summary>
        /// <param name="recordToUpdate"></param>
        public virtual void Update(TRecord recordToUpdate)
        {
            DbSet.Attach(recordToUpdate);
            //Context.Entry(recordToUpdate).State = EntityState.Modified;
        }
    }
}
