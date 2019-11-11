using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElevatorCore.Elevator.Abstract;
using ElevatorCore.Elevator.Concrete;
using ElevatorCore.Utils;
using ElevatorCore.Utils.Abstract;

namespace ElevatorCore.Elevator
{
    public class Elevator
    {
        private readonly ILogger _logger;
        private IElevatorState _currentState;
        private Action<int> _closeDoorsAction;
        private Action<int> _openDoorsAction;
        private Action<int> _moveElevatorAction;
        public ElevatorPositionHelper ElevatorPosition { get; set; }
        public int DestinationFloor { get; set; }
        public int StartFloor { get; set; }

        public Elevator(ILogger logger)
        {
            _logger = logger;
            _currentState = new ElevatorStationary(this, logger);
        }

        public void Init(Action<int> moveElevatorAction, Action<int> closeDoorsAction, Action<int> openDoorsAction)
        {
            _moveElevatorAction = moveElevatorAction;
            _closeDoorsAction = closeDoorsAction;
            _openDoorsAction = openDoorsAction;
        }
        public void SetState(IElevatorState elevatorState)
        {
            _currentState = elevatorState;
        }

        public void CallForElevator(int floorNumber)
        {
            _currentState.MoveElevator(floorNumber);
        }

        public void OpenDoors()
        {
            _openDoorsAction(DestinationFloor);
        }

        public void CloseDoors()
        {
            _closeDoorsAction(DestinationFloor);
            //todo:_le
        }

        public void MoveElevator()
        {
            _moveElevatorAction(DestinationFloor);
            _logger.LogElevatorStartedMoving(DestinationFloor);
            //todo
        }
    }
}
