using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElevatorCore.DataAccess.Abstract;
using ElevatorCore.DataAccess.Model;
using ElevatorCore.Utils;

namespace ElevatorCore.DataAccess.Concrete
{
    /// <summary>
    /// Concrete implementation of the Unit Of Work pattern
    /// </summary>
    public class Session : ISession
    {
        /// <summary>
        /// EF6 database context
        /// </summary>
        private readonly ElevatorContext _context;
        
        private IRepository<Log> _logs;

        /// <summary>
        /// Repository of Log
        /// </summary>
        public IRepository<Log> Logs => _logs ?? (_logs = new BaseRepository<Log>(_context));

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbContext">Entity Framework 6 database context</param>
        public Session(ElevatorContext dbContext)
        {
            _context = dbContext;
        }
        /// <summary>
        /// Saves all changes made in database
        /// </summary>
        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // log any exceptions and show error message
                Logger.Instance(this).LogError(ex.Message);
                //basic handle of an error
                MessageBox.Show("There was an error while saving changes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
