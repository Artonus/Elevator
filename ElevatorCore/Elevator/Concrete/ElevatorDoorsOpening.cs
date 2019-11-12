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
    /// Represents the temporary state of the elevator doors opening
    /// </summary>
    public class ElevatorDoorsOpening : IElevatorState
    {
        /// <summary>
        /// Elevator instance
        /// </summary>
        private readonly Elevator _elevator;

        /// <summary>
        /// Logger instance
        /// </summary>
        private readonly ILogger _logger;

        public ElevatorDoorsOpening(Elevator elevator, ILogger logger)
        {
            _elevator = elevator;
            _logger = logger;

            _elevator.OpenDoors();
            _logger.LogElevatorOpeningDoors(_elevator.DestinationFloor);
        }

        /// <summary>
        /// Moves elevator requested floor
        /// </summary>
        /// <param name="floorNumber"></param>
        public void MoveElevator(int floorNumber)
        {
            _logger.LogElevatorDoorsAlreadyOpening(_elevator.DestinationFloor);
        }
    }
}
