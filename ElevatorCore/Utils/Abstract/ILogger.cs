using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.Utils.Abstract
{
    public interface ILogger
    {
        void LogElevatorArrivedAtFloor(int floorNumber);
        void LogElevatorCalledToFloor(int floorNumber);
        void LogElevatorAlreadyMovingToFloor(int floorNumber);
        void LogElevatorStartedMoving(int floorNumber);
        void LogError(string message);
    }
}
