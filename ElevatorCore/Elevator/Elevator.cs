using System;
using ElevatorCore.Elevator.Abstract;
using ElevatorCore.Elevator.Concrete;
using ElevatorCore.Utils;
using ElevatorCore.Utils.Abstract;

namespace ElevatorCore.Elevator
{
    /// <summary>
    /// Represents the current status of the Elevator in the shaft
    /// </summary>
    public class Elevator
    {
        /// <summary>
        /// Logger instance
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Current state of the elevator
        /// </summary>
        private IElevatorState _currentState;
        /// <summary>
        /// Close doors action from MainForm
        /// </summary>
        private Action<int> _closeDoorsAction;
        /// <summary>
        /// Open doors action from MainForm
        /// </summary>
        private Action<int> _openDoorsAction;
        /// <summary>
        /// Move elevator action from MainForm
        /// </summary>
        private Action<int> _moveElevatorAction;
        /// <summary>
        /// Information about position of the elevator while moving
        /// </summary>
        public ElevatorPositionHelper ElevatorPosition { get; set; }
        /// <summary>
        /// Floor that elevator is heading to
        /// </summary>
        public int DestinationFloor { get; set; }
        /// <summary>
        /// Floor that elevator started moving
        /// </summary>
        public int StartFloor { get; set; }

        /// <summary>
        /// Default c-tor
        /// </summary>
        /// <param name="logger"></param>
        public Elevator(ILogger logger)
        {
            _logger = logger;
            // initialization of default state of the elevator
            _currentState = new ElevatorStationary(this, logger);
        }

        /// <summary>
        /// Initializes all necessary methods to make elevator work
        /// </summary>
        /// <param name="moveElevatorAction">Method to move the elevator</param>
        /// <param name="closeDoorsAction">Method to close doors</param>
        /// <param name="openDoorsAction">Method to open doors</param>
        public void Init(Action<int> moveElevatorAction, Action<int> closeDoorsAction, Action<int> openDoorsAction)
        {
            _moveElevatorAction = moveElevatorAction;
            _closeDoorsAction = closeDoorsAction;
            _openDoorsAction = openDoorsAction;
        }

        /// <summary>
        /// Sets the state of the elevator
        /// </summary>
        /// <param name="elevatorState"></param>
        public void SetState(IElevatorState elevatorState)
        {
            _currentState = elevatorState;
        }

        /// <summary>
        /// Calls the elevator for requested floor
        /// </summary>
        /// <param name="floorNumber"></param>
        public void CallForElevator(int floorNumber)
        {
            _currentState.MoveElevator(floorNumber);
        }

        /// <summary>
        /// Opens the doors on the floor that elevator currently stays on 
        /// </summary>
        public void OpenDoors()
        {
            _openDoorsAction(DestinationFloor);
        }

        /// <summary>
        /// Closes the doors on the floor that elevator currently stays on
        /// </summary>
        public void CloseDoors()
        {
            _closeDoorsAction(DestinationFloor);
        }

        /// <summary>
        /// Moves elevator to destination floor
        /// </summary>
        public void MoveElevator()
        {
            _moveElevatorAction(DestinationFloor);
            //logs the elevator started moving
            _logger.LogElevatorStartedMoving(DestinationFloor);
        }
    }
}
