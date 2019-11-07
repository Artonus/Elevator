using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.Elevator.Abstract
{
    public interface IFloor
    {
        void SetElevatorOnFloorDisplay(int floorNumber);
        void CloseElevatorDoor(int floorNumber);

        void OpenElevatorDoor(int floorNumber);
    }
}
