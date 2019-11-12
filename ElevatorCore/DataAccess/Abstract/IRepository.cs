using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.DataAccess.Model;

namespace ElevatorCore.DataAccess.Abstract
{
    /// <summary>
    /// Gives access to records of database records
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Deletes the entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(TEntity entity);
        /// <summary>
        /// Deletes the entity
        /// </summary>
        /// <param name="id">Entity's ID</param>
        void Delete(object id);
        /// <summary>
        /// Finds entity
        /// </summary>
        /// <param name="id">Entity's ID</param>
        /// <returns></returns>
        TEntity GetByID(object id);
        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>Collection of entity objects</returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Adds new entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Insert(TEntity entity);
        /// <summary>
        /// Updates the entity
        /// </summary>
        /// <param name="entityToUpdate">Entity to update</param>
        void Update(TEntity entityToUpdate);
    }
}
