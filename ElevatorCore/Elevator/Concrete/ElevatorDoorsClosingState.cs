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
    /// Represents the temporary state of the elevator doors closing
    /// </summary>
    public class ElevatorDoorsClosingState : IElevatorState
    {
        /// <summary>
        /// Elevator instance
        /// </summary>
        private readonly Elevator _elevator;

        /// <summary>
        /// Logger instance
        /// </summary>
        private readonly ILogger _logger;

        public ElevatorDoorsClosingState(Elevator elevator, ILogger logger)
        {
            _elevator = elevator;
            _logger = logger;
            // call elevator doors to close at initialization of the state
            _elevator.CloseDoors();
            _logger.LogElevatorClosingDoors(elevator.DestinationFloor);
        }

        /// <summary>
        /// Moves elevator requested floor
        /// </summary>
        /// <param name="floorNumber"></param>
        public void MoveElevator(int floorNumber)
        {
            // do nothing, report that doors are already closing
            _logger.LogElevatorDoorsAlreadyClosing(_elevator.DestinationFloor);
        }
    }
}
