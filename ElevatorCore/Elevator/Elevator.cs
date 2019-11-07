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
using ElevatorCore.Utils.Abstract;

namespace ElevatorCore.Elevator
{
    public class Elevator
    {
        private IElevatorState _currentState;
        public int CurrentFloor { get; set; }
        public Elevator(ILogger logger)
        {
            _currentState = new ElevatorStationary(this, logger);
        }
        public void SetState(IElevatorState elevatorState)
        {
            _currentState = elevatorState;
        }

        public void CallForElevator(int floorNumber, Action<int> elevatorCalledAction)
        {
            _currentState.MoveElevator(floorNumber, elevatorCalledAction);
        }
    }
}
