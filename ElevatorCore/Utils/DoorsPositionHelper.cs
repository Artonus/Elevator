using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.Utils
{
    public class DoorsPositionHelper
    {
        public int StartPosition { get; set; }
        public int DestinationPosition { get; set; }

        public bool ActionEnded { get; set; } = false;
        public bool Opening { get; set; }
    }
}
