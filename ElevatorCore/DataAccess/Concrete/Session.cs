using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElevatorCore.DataAccess.Abstract;
using ElevatorCore.DataAccess.Model;

namespace ElevatorCore.DataAccess.Concrete
{
    public class Session : ISession
    {
        private ElevatorContext _context;

        private IRepository<Log> _logs;

        public IRepository<Log> Logs => _logs ?? (_logs = new BaseRepository<Log>(_context));

        public Session(ElevatorContext dbContext)
        {
            _context = dbContext;
        }
        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //basic handle of an error
                MessageBox.Show("There was an error while saving changes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
