using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.Elevator.Abstract
{
    /// <summary>
    /// Interface that defines Floor and its methods
    /// </summary>
    public interface IFloor
    {
        /// <summary>
        /// Sets floor number on floor display
        /// </summary>
        /// <param name="floorNumber"></param>
        void SetElevatorOnFloorDisplay(int floorNumber);

        /// <summary>
        /// Closes elevator doors on selected floor
        /// </summary>
        /// <param name="floorNumber"></param>
        void CloseElevatorDoor(int floorNumber);

        /// <summary>
        /// Opens elevator doors on selected floor
        /// </summary>
        /// <param name="floorNumber"></param>
        void OpenElevatorDoor(int floorNumber);
    }
}
