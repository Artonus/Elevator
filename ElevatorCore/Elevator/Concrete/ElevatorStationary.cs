using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.Elevator.Abstract;

namespace ElevatorCore.Elevator.Concrete
{
    public class ElevatorStationary : IElevatorState
    {
        private readonly Elevator _elevator;
        public ElevatorStationary(Elevator elevator)
        {
            _elevator = elevator;
        }
        public void MoveElevator(int floorNumber, Action<int> moveElevatorAction)
        {
            moveElevatorAction(floorNumber);
            _elevator.CurrentFloor = floorNumber;
            _elevator.SetState(new ElevatorMoving(_elevator));
        }
    }
}
