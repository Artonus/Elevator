using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.Elevator.Abstract
{
    public interface IElevatorState
    {
        void MoveElevator(int floorNumber);
    }
}
