using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.Utils
{
    /// <summary>
    /// Helper class that contains variables necessary to manage doors opening and closing
    /// </summary>
    public class DoorsPositionHelper
    {
        public int StartPosition { get; set; }
        public int DestinationPosition { get; set; }
        /// <summary>
        /// Determines either action has ended or not 
        /// </summary>
        public bool ActionEnded { get; set; } = false;
        /// <summary>
        /// Determines if the doors are opening or not
        /// </summary>
        public bool Opening { get; set; }
    }
}
