using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.Elevator.Abstract;

namespace ElevatorCore.Elevator.Concrete
{
    class ElevatorStationary : IElevatorState
    {
        private ElevatorCore.Elevator.Elevator _elevator;

        public ElevatorStationary(ElevatorCore.Elevator.Elevator elevator)
        {
            _elevator = elevator;
        }

        public void CallForElevator(int floorNumber)
        {
            throw new NotImplementedException();
            //MoveElevator
        }

        public void MoveElevator(int floorNumber)
        {
            throw new NotImplementedException();

        }
    }
}
