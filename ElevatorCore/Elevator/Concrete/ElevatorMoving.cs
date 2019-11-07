using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.Elevator.Abstract;

namespace ElevatorCore.Elevator.Concrete
{
    public class ElevatorMoving : IElevatorState
    {
        private Elevator _elevator;
        public ElevatorMoving(Elevator elevator)
        {
            _elevator = elevator;
        }
        public void MoveElevator(int floorNumber, Action<int> moveElevatorAction)
        {
            // do nothing, elevator is already moving
            return;
        }
    }
}
