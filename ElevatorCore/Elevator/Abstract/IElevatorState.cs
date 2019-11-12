using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.Elevator.Abstract
{
    /// <summary>
    /// Interface for Elevator State
    /// </summary>
    public interface IElevatorState
    {
        /// <summary>
        /// Moves Elevator to requested floor
        /// </summary>
        /// <param name="floorNumber">Requested floor number</param>
        void MoveElevator(int floorNumber);
    }
}
