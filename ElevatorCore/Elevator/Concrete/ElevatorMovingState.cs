using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.Elevator.Abstract;
using ElevatorCore.Utils.Abstract;

namespace ElevatorCore.Elevator.Concrete
{
    /// <summary>
    /// Represents the temporary state of the elevator moving
    /// </summary>
    public class ElevatorMovingState : IElevatorState
    {
        /// <summary>
        /// Elevator instance
        /// </summary>
        private readonly Elevator _elevator;

        /// <summary>
        /// Logger instance
        /// </summary>
        private readonly ILogger _logger;

        public ElevatorMovingState(Elevator elevator, ILogger logger)
        {
            _elevator = elevator;
            _logger = logger;
            // calls to move elevator to requested floor after the change of the state
            _elevator.MoveElevator();
        }

        /// <summary>
        /// Moves elevator requested floor
        /// </summary>
        /// <param name="floorNumber"></param>
        public void MoveElevator(int floorNumber)
        {
            // do nothing, elevator is already moving and log event cancelled 
            _logger.LogElevatorAlreadyMovingToFloor(_elevator.DestinationFloor);
        }
    }
}
