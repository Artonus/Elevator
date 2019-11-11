using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.Elevator.Abstract;
using ElevatorCore.Utils.Abstract;

namespace ElevatorCore.Elevator.Concrete
{
    public class ElevatorDoorsOpening : IElevatorState
    {
        private readonly Elevator _elevator;
        private readonly ILogger _logger;

        public ElevatorDoorsOpening(Elevator elevator, ILogger logger)
        {
            _elevator = elevator;
            _logger = logger;

            _elevator.OpenDoors();
            _logger.LogElevatorOpeningDoors(_elevator.DestinationFloor);
        }
        public void MoveElevator(int floorNumber)
        {
            _logger.LogElevatorDoorsAlreadyOpening(_elevator.DestinationFloor);
        }
    }
}
