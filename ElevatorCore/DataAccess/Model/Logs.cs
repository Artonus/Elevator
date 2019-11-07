using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.DataAccess.Model
{
    public class Logs
    {
        [Key]
        public int ID { get; set; }
        public string Timestamp { get; set; }
        public string Description { get; set; }
    }
}
