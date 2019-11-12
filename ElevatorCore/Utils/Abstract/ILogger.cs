using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.Utils.Abstract
{
    /// <summary>
    /// Logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs Elevator arrived at floor
        /// </summary>
        /// <param name="floorNumber"></param>
        void LogElevatorArrivedAtFloor(int floorNumber);
        /// <summary>
        /// Logs Elevator was called to floor
        /// </summary>
        /// <param name="floorNumber"></param>
        void LogElevatorCalledToFloor(int floorNumber);
        /// <summary>
        /// Log Elevator is already moving to floor
        /// </summary>
        /// <param name="floorNumber"></param>
        void LogElevatorAlreadyMovingToFloor(int floorNumber);
        /// <summary>
        /// Log Elevator started moving
        /// </summary>
        /// <param name="floorNumber"></param>
        void LogElevatorStartedMoving(int floorNumber);
        /// <summary>
        /// Log Elevator doors are closing
        /// </summary>
        /// <param name="floorNumber"></param>
        void LogElevatorClosingDoors(int floorNumber);
        /// <summary>
        /// Log Elevator doors are already closing
        /// </summary>
        /// <param name="floorNumber"></param>
        void LogElevatorDoorsAlreadyClosing(int floorNumber);
        /// <summary>
        /// Log Elevator doors are opening
        /// </summary>
        /// <param name="floorNumber"></param>
        void LogElevatorOpeningDoors(int floorNumber);
        /// <summary>
        /// Log Elevator doors are already opening
        /// </summary>
        /// <param name="floorNumber"></param>
        void LogElevatorDoorsAlreadyOpening(int floorNumber);
        /// <summary>
        /// Los error
        /// </summary>
        /// <param name="message"></param>
        void LogError(string message);
    }
}
