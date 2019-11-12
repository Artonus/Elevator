using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.DataAccess.Model
{
    /// <summary>
    /// Class that represents Log entity in database
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Timestamp when record was created
        /// </summary>
        public string Timestamp { get; set; }
        /// <summary>
        /// Description of an event
        /// </summary>
        public string Description { get; set; }
    }
}
