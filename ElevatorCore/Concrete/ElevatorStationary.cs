using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.Abstract;

namespace ElevatorCore.Concrete
{
    class ElevatorStationary : IElevatorState
    {
        private Elevator _elevator;

        public ElevatorStationary(Elevator elevator)
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
