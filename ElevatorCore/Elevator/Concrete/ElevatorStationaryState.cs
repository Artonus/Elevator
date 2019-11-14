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
    /// Represents the state of the elevator when it is stationary at the floor
    /// </summary>
    public class ElevatorStationaryState : IElevatorState
    {
        /// <summary>
        /// Elevator instance
        /// </summary>
        private readonly Elevator _elevator;

        /// <summary>
        /// Logger instance
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="elevator"></param>
        /// <param name="logger"></param>
        public ElevatorStationaryState(Elevator elevator, ILogger logger)
        {
            _logger = logger;
            _elevator = elevator;
        }

        /// <summary>
        /// Moves elevator requested floor
        /// </summary>
        /// <param name="floorNumber"></param>
        public void MoveElevator(int floorNumber)
        {
            _elevator.SetState(new ElevatorDoorsClosingState(_elevator, _logger));
            _elevator.StartFloor = _elevator.DestinationFloor;
            _elevator.DestinationFloor = floorNumber;
            
        }
    }
}
