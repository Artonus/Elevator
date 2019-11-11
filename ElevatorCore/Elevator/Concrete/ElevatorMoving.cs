using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.Elevator.Abstract;
using ElevatorCore.Utils.Abstract;

namespace ElevatorCore.Elevator.Concrete
{
    public class ElevatorMoving : IElevatorState
    {
        private readonly Elevator _elevator;
        private readonly ILogger _logger;

        public ElevatorMoving(Elevator elevator, ILogger logger)
        {
            _elevator = elevator;
            _logger = logger;
            _elevator.MoveElevator();
        }
        public void MoveElevator(int floorNumber)
        {
            // do nothing, elevator is already moving
            _logger.LogElevatorAlreadyMovingToFloor(_elevator.DestinationFloor);
        }
    }
}
