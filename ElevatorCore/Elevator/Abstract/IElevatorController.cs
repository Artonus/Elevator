using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.Elevator.Abstract
{
    /// <summary>
    /// Interface for Elevator Panel Control
    /// </summary>
    public interface IElevatorController
    {
        /// <summary>
        /// Sets the floor on display
        /// </summary>
        /// <param name="floorNumber"></param>
        void SetFloor(int floorNumber);
    }
}
